using apiPeliculas.DTOs;
using apiPeliculas.Helpers;
using apiPeliculas.Models;
using apiPeliculas.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActoresController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActores()
        {
            var actores = await _unitOfWork.Actor.GetAllAsync();
            var actoresDTO = _mapper.Map<List<ActorDTO>>(actores);
            return Ok(ApiResponse<List<ActorDTO>>.Ok(actoresDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor(int id)
        {
            var actor = await _unitOfWork.Actor.GetFirstOrDefaultAsync(a => a.Id == id);
            if (actor == null)
            {
                return NotFound(ApiResponse<string>.Error($"El actor con ID {id} no existe"));
            }

            var actorDTO = _mapper.Map<ActorDTO>(actor);
            return Ok(ApiResponse<ActorDTO>.Ok(actorDTO));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CrearActor([FromBody] ActorDTO actorDTO)
        {
            if (actorDTO == null)
            {
                return BadRequest(ApiResponse<string>.Error("Los datos del actor son obligatorios"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de actor inválidos",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var actor = _mapper.Map<Actor>(actorDTO);
            actor.FechaCreacion = DateTime.Now;

            await _unitOfWork.Actor.AddAsync(actor);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetActor), new { id = actor.Id },
                ApiResponse<ActorDTO>.Ok(_mapper.Map<ActorDTO>(actor), "Actor creado correctamente"));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ActualizarActor(int id, [FromBody] ActorDTO actorDTO)
        {
            if (actorDTO == null || id != actorDTO.Id)
            {
                return BadRequest(ApiResponse<string>.Error("ID de actor inválido"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de actor inválidos",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var actor = await _unitOfWork.Actor.GetFirstOrDefaultAsync(a => a.Id == id);
            if (actor == null)
            {
                return NotFound(ApiResponse<string>.Error($"El actor con ID {id} no existe"));
            }

            actor.Nombre = actorDTO.Nombre;
            actor.FotoUrl = actorDTO.FotoUrl;
            actor.Biografia = actorDTO.Biografia;

            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<ActorDTO>.Ok(_mapper.Map<ActorDTO>(actor), "Actor actualizado correctamente"));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> EliminarActor(int id)
        {
            var actor = await _unitOfWork.Actor.GetFirstOrDefaultAsync(a => a.Id == id);
            if (actor == null)
            {
                return NotFound(ApiResponse<string>.Error($"El actor con ID {id} no existe"));
            }

            await _unitOfWork.Actor.RemoveAsync(actor);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<string>.Ok("Actor eliminado correctamente"));
        }
    }
}