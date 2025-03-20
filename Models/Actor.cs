using System.ComponentModel.DataAnnotations;

namespace apiPeliculas.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del actor es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [MaxLength(200, ErrorMessage = "La URL de la foto no puede exceder los 200 caracteres")]
        public string FotoUrl { get; set; }

        [MaxLength(500, ErrorMessage = "La biografía no puede exceder los 500 caracteres")]
        public string Biografia { get; set; }

        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public ICollection<PeliculaActor> PeliculaActores { get; set; }
    }
} 