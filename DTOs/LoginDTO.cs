using System.ComponentModel.DataAnnotations;

namespace apiPeliculas.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
} 