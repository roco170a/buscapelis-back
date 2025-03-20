using System.ComponentModel.DataAnnotations;

namespace apiPeliculas.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 20 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
} 