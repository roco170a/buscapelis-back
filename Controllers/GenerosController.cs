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
    public class GenerosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenerosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var generos = await _unitOfWork.Genero.GetAllAsync();
            var generosDTO = _mapper.Map<List<GeneroDTO>>(generos);
            return Ok(ApiResponse<List<GeneroDTO>>.Ok(generosDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenero(int id)
        {
            var genero = await _unitOfWork.Genero.GetFirstOrDefaultAsync(g => g.Id == id);
            if (genero == null)
            {
                return NotFound(ApiResponse<string>.Error($"El género con ID {id} no existe"));
            }

            var generoDTO = _mapper.Map<GeneroDTO>(genero);
            return Ok(ApiResponse<GeneroDTO>.Ok(generoDTO));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CrearGenero([FromBody] GeneroDTO generoDTO)
        {
            if (generoDTO == null)
            {
                return BadRequest(ApiResponse<string>.Error("Los datos del género son obligatorios"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de género inválidos",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var genero = _mapper.Map<Genero>(generoDTO);
            genero.FechaCreacion = DateTime.Now;

            await _unitOfWork.Genero.AddAsync(genero);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetGenero), new { id = genero.Id },
                ApiResponse<GeneroDTO>.Ok(_mapper.Map<GeneroDTO>(genero), "Género creado correctamente"));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ActualizarGenero(int id, [FromBody] GeneroDTO generoDTO)
        {
            if (generoDTO == null || id != generoDTO.Id)
            {
                return BadRequest(ApiResponse<string>.Error("ID de género inválido"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de género inválidos",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var genero = await _unitOfWork.Genero.GetFirstOrDefaultAsync(g => g.Id == id);
            if (genero == null)
            {
                return NotFound(ApiResponse<string>.Error($"El género con ID {id} no existe"));
            }

            genero.Nombre = generoDTO.Nombre;
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<GeneroDTO>.Ok(_mapper.Map<GeneroDTO>(genero), "Género actualizado correctamente"));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> EliminarGenero(int id)
        {
            var genero = await _unitOfWork.Genero.GetFirstOrDefaultAsync(g => g.Id == id);
            if (genero == null)
            {
                return NotFound(ApiResponse<string>.Error($"El género con ID {id} no existe"));
            }

            await _unitOfWork.Genero.RemoveAsync(genero);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponse<string>.Ok("Género eliminado correctamente"));
        }
    }
} 