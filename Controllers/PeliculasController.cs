using apiPeliculas.DTOs;
using apiPeliculas.Helpers;
using apiPeliculas.Models;
using apiPeliculas.Repository;
using apiPeliculas.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeliculasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeliculas()
        {
            var peliculas = await _unitOfWork.Pelicula.GetAllAsync(includeProperties: "PeliculaGeneros.Genero,PeliculaActores.Actor");
            var peliculasDTO = _mapper.Map<List<PeliculaDTO>>(peliculas);
            return Ok(ApiResponse<List<PeliculaDTO>>.Ok(peliculasDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPelicula(int id)
        {
            var pelicula = await _unitOfWork.Pelicula.GetFirstOrDefaultAsync(
                p => p.Id == id, 
                includeProperties: "PeliculaGeneros.Genero,PeliculaActores.Actor");

            if (pelicula == null)
            {
                return NotFound(ApiResponse<string>.Error($"La película con ID {id} no existe"));
            }

            var peliculaDTO = _mapper.Map<PeliculaDTO>(pelicula);
            return Ok(ApiResponse<PeliculaDTO>.Ok(peliculaDTO));
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPeliculas([FromQuery] string criterioBusqueda)
        {
            var peliculas = await _unitOfWork.Pelicula.BuscarPorCriterios(criterioBusqueda);
            var peliculasDTO = _mapper.Map<List<PeliculaDTO>>(peliculas);
            return Ok(ApiResponse<List<PeliculaDTO>>.Ok(peliculasDTO));
        }

        [HttpGet("porGenero/{generoId}")]
        public async Task<IActionResult> GetPeliculasPorGenero(int generoId)
        {
            var peliculas = await _unitOfWork.Pelicula.BuscarPorGenero(generoId);
            var peliculasDTO = _mapper.Map<List<PeliculaDTO>>(peliculas);
            return Ok(ApiResponse<List<PeliculaDTO>>.Ok(peliculasDTO));
        }

        [HttpGet("porActor/{actorId}")]
        public async Task<IActionResult> GetPeliculasPorActor(int actorId)
        {
            var peliculas = await _unitOfWork.Pelicula.BuscarPorActor(actorId);
            var peliculasDTO = _mapper.Map<List<PeliculaDTO>>(peliculas);
            return Ok(ApiResponse<List<PeliculaDTO>>.Ok(peliculasDTO));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CrearPelicula([FromBody] PeliculaDTO peliculaDTO)
        {
            if (peliculaDTO == null)
            {
                return BadRequest(ApiResponse<string>.Error("Los datos de la película son obligatorios"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de película inválidos",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var pelicula = _mapper.Map<Pelicula>(peliculaDTO);
            pelicula.FechaCreacion = DateTime.Now;

            await _unitOfWork.Pelicula.AddAsync(pelicula);
            await _unitOfWork.SaveAsync();

            // RCC Assign genres
            if (peliculaDTO.Generos != null && peliculaDTO.Generos.Any())
            {                
                foreach (var generoDTO in peliculaDTO.Generos)
                {   
                    // RCC Try to locate the genre
                    var generoExistente = await _unitOfWork.Genero.GetByIdAsync(generoDTO.GeneroId);
                    if (generoExistente != null)
                    {
                        var peliculaGenero = new PeliculaGenero
                        {
                            PeliculaId = generoDTO.GeneroId,
                            Pelicula = pelicula,
                            GeneroId = generoDTO.GeneroId,
                            Genero = generoExistente
                        };
                        await _unitOfWork.PeliculaGenero.AddAsync(peliculaGenero);
                    }
                    else 
                    {
                        var generoNuevo = new Genero { Nombre = generoDTO.NombreGenero };
                        await _unitOfWork.Genero.AddAsync(generoNuevo);
                        await _unitOfWork.SaveAsync();
                        var peliculaGenero = new PeliculaGenero
                        {
                            PeliculaId = generoDTO.GeneroId,
                            Pelicula = pelicula,
                            GeneroId = generoDTO.GeneroId,
                            Genero = generoNuevo
                        };
                        await _unitOfWork.PeliculaGenero.AddAsync(peliculaGenero);
                    }
                    
                }
                await _unitOfWork.SaveAsync();
            }

            // RCC Assign actors
            if (peliculaDTO.Actores != null && peliculaDTO.Actores.Any())
            {
                foreach (var actorDTO in peliculaDTO.Actores)
                {   
                    // RCC Try to locate the actor
                    var actorExistente = await _unitOfWork.Actor.GetByIdAsync(actorDTO.ActorId);
                    if (actorExistente != null) {
                        var peliculaActor = new PeliculaActor
                        {
                            PeliculaId = pelicula.Id,
                            Pelicula = pelicula,
                            ActorId = actorDTO.ActorId,
                            Actor = actorExistente,
                            Personaje = actorDTO.Personaje
                        };
                        await _unitOfWork.PeliculaActor.AddAsync(peliculaActor);
                    } else {
                        var actorNuevo = new Actor { Nombre = actorDTO.NombreActor, Biografia = "", FotoUrl = "" };
                        await _unitOfWork.Actor.AddAsync(actorNuevo);
                        await _unitOfWork.SaveAsync();
                        var peliculaActor = new PeliculaActor
                        {
                            PeliculaId = pelicula.Id,
                            Pelicula = pelicula,
                            ActorId = actorDTO.ActorId,
                            Actor = actorNuevo,
                            Personaje = actorDTO.Personaje
                        };
                    }
                }
                await _unitOfWork.SaveAsync();
            }

            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, 
                ApiResponse<PeliculaDTO>.Ok(_mapper.Map<PeliculaDTO>(pelicula), "Película creada correctamente"));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ActualizarPelicula(int id, [FromBody] PeliculaDTO peliculaDTO)
        {
            if (peliculaDTO == null || id != peliculaDTO.Id)
            {
                return BadRequest(ApiResponse<string>.Error("ID de película inválido"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de película inválidos",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var pelicula = await _unitOfWork.Pelicula.GetFirstOrDefaultAsync(p => p.Id == id);

            //Eliminar de la base de datos los generos y actores que ya no estan en la pelicula
            var generosParaEliminar = _unitOfWork.PeliculaGenero.GetAllAsync( r => r.PeliculaId == pelicula.Id).Result.Where(pg => !peliculaDTO.Generos.Any(g => g.GeneroId == pg.GeneroId && pg.PeliculaId == pelicula.Id)).ToList();
            var actoresParaEliminar = _unitOfWork.PeliculaActor.GetAllAsync(r => r.PeliculaId == pelicula.Id ).Result.Where(pa => !peliculaDTO.Actores.Any(a => a.ActorId == pa.ActorId && pa.PeliculaId == pelicula.Id)).ToList();
            foreach (var genero in generosParaEliminar)
            {
                await _unitOfWork.PeliculaGenero.RemoveAsync(genero);
            }
            foreach (var actor in actoresParaEliminar)
            {
                await _unitOfWork.PeliculaActor.RemoveAsync(actor);
            }
            await _unitOfWork.SaveAsync();

            if (pelicula == null)
            {
                return NotFound(ApiResponse<string>.Error($"La película con ID {id} no existe"));
            }

            // RCC Assign genres
            if (peliculaDTO.Generos != null && peliculaDTO.Generos.Any())
            {
                foreach (var generoDTO in peliculaDTO.Generos)
                {
                    //Revisar si el genero existe relacionado con la pelicula
                    var peliculaGeneroExistente = await _unitOfWork.PeliculaGenero.GetFirstOrDefaultAsync(pg => pg.PeliculaId == pelicula.Id && pg.GeneroId == generoDTO.GeneroId);
                    if (peliculaGeneroExistente != null)
                    {
                        pelicula.PeliculaGeneros.Add(peliculaGeneroExistente);
                        continue;
                    } else {
                        // RCC Try to locate the genre
                        var generoExistente = await _unitOfWork.Genero.GetByIdAsync(generoDTO.GeneroId);
                        if (generoExistente != null)
                        {
                            var peliculaGenero = new PeliculaGenero
                            {
                                PeliculaId = generoDTO.GeneroId,
                                Pelicula = pelicula,
                                GeneroId = generoDTO.GeneroId,
                                Genero = generoExistente
                            };
                            await _unitOfWork.PeliculaGenero.AddAsync(peliculaGenero);
                        }
                        else
                        {
                            var generoNuevo = new Genero { Nombre = generoDTO.NombreGenero };
                            await _unitOfWork.Genero.AddAsync(generoNuevo);
                            await _unitOfWork.SaveAsync();
                            var peliculaGenero = new PeliculaGenero
                            {
                                PeliculaId = generoDTO.GeneroId,
                                Pelicula = pelicula,
                                GeneroId = generoDTO.GeneroId,
                                Genero = generoNuevo
                            };
                            await _unitOfWork.PeliculaGenero.AddAsync(peliculaGenero);
                        }
                    }
                }
                await _unitOfWork.SaveAsync();
            }

            // RCC Assign actors
            if (peliculaDTO.Actores != null && peliculaDTO.Actores.Any())
            {
                foreach (var actorDTO in peliculaDTO.Actores)
                {
                    //Revisar si el actor existe relacionado con la pelicula
                    var peliculaActorExistente = await _unitOfWork.PeliculaActor.GetFirstOrDefaultAsync(pa => pa.PeliculaId == pelicula.Id && pa.ActorId == actorDTO.ActorId);
                    if (peliculaActorExistente != null)
                    {
                        pelicula.PeliculaActores.Add(peliculaActorExistente);
                        continue;
                    } else {
                        // RCC Try to locate the actor
                        var actorExistente = await _unitOfWork.Actor.GetByIdAsync(actorDTO.ActorId);
                        if (actorExistente != null)
                        {
                            var peliculaActor = new PeliculaActor
                            {
                                PeliculaId = pelicula.Id,
                                Pelicula = pelicula,
                                ActorId = actorDTO.ActorId,
                                Actor = actorExistente,
                                Personaje = actorDTO.Personaje
                            };
                            await _unitOfWork.PeliculaActor.AddAsync(peliculaActor);
                        }
                        else
                        {
                            var actorNuevo = new Actor { Nombre = actorDTO.NombreActor, Biografia = "", FotoUrl = "" };
                            await _unitOfWork.Actor.AddAsync(actorNuevo);
                            await _unitOfWork.SaveAsync();
                            var peliculaActor = new PeliculaActor
                            {
                                PeliculaId = pelicula.Id,
                                Pelicula = pelicula,
                                ActorId = actorDTO.ActorId,
                                Actor = actorNuevo,
                                Personaje = actorDTO.Personaje
                            };
                        }
                    }
                }
                await _unitOfWork.SaveAsync();
            }

            // RCC Update movie fields
            pelicula.Titulo = peliculaDTO.Titulo;
            pelicula.Sinopsis = peliculaDTO.Sinopsis;
            pelicula.Anio = peliculaDTO.Anio;
            pelicula.ImagenUrl = peliculaDTO.ImagenUrl;
                        
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<Pelicula>.Ok(pelicula, "Película actualizada correctamente"));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> EliminarPelicula(int id)
        {
            var pelicula = await _unitOfWork.Pelicula.GetFirstOrDefaultAsync(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound(ApiResponse<string>.Error($"La película con ID {id} no existe"));
            }

            await _unitOfWork.Pelicula.RemoveAsync(pelicula);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<string>.Ok("Película eliminada correctamente"));
        }
    }
}