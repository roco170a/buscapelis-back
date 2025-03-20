using apiPeliculas.DTOs;
using apiPeliculas.Helpers;
using apiPeliculas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apiPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtGenerator _jwtGenerator;

        public UsuariosController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            JwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de registro inválidos", 
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var usuario = new ApplicationUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Nombre = registerDTO.Nombre,
                FechaCreacion = DateTime.Now
            };

            var resultado = await _userManager.CreateAsync(usuario, registerDTO.Password);

            if (!resultado.Succeeded)
            {
                var errorMessages = resultado.Errors.Select(e => e.Description).ToList(); 
                return BadRequest(ApiResponse<string>.Error("Error al registrar el usuario", errorMessages));
            }

            // Asignar rol por defecto (Usuario)
            // RCC Assign default role (User)
            if (!await _roleManager.RoleExistsAsync("Usuario"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Usuario"));
            }

            await _userManager.AddToRoleAsync(usuario, "Usuario");

            return Ok(ApiResponse<string>.Ok("Usuario registrado correctamente"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Error("Datos de inicio de sesión inválidos", 
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var resultado = await _signInManager.PasswordSignInAsync(
                loginDTO.UserName, loginDTO.Password, false, false);

            if (!resultado.Succeeded)
            {
                return Unauthorized(ApiResponse<string>.Error("Credenciales incorrectas"));
            }

            var usuario = await _userManager.FindByNameAsync(loginDTO.UserName);

            var userDto = new UserDTO
            {
                Id = usuario.Id,
                UserName = usuario.UserName,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Token = await _jwtGenerator.GenerateToken(usuario)
            };

            return Ok(ApiResponse<UserDTO>.Ok(userDto, "Inicio de sesión exitoso"));
        }

        [HttpGet("roles")]
        [Authorize]
        public async Task<IActionResult> GetRoles()
        {
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();
            return Ok(ApiResponse<List<string>>.Ok(roles, "Lista de roles"));
        }

        [HttpPost("asignar-rol")]
        [Authorize]
        public async Task<IActionResult> AsignarRol(string userName, string roleName)
        {
            var usuario = await _userManager.FindByNameAsync(userName);
            if (usuario == null)
            {
                return NotFound(ApiResponse<string>.Error($"No se encontró el usuario {userName}"));
            }

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                return BadRequest(ApiResponse<string>.Error($"El rol {roleName} no existe"));
            }

            await _userManager.AddToRoleAsync(usuario, roleName);
            return Ok(ApiResponse<string>.Ok($"Rol {roleName} asignado al usuario {userName}"));
        }
    }
} 