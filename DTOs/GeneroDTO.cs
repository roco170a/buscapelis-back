using System.ComponentModel.DataAnnotations;

namespace apiPeliculas.DTOs
{
    public class GeneroDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del género es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
} 