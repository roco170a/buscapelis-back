using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiPeliculas.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [MaxLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "La sinopsis no puede exceder los 500 caracteres")]
        public string Sinopsis { get; set; }

        [Required(ErrorMessage = "El año de lanzamiento es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Anio { get; set; }

        [MaxLength(200, ErrorMessage = "La URL de la imagen no puede exceder los 200 caracteres")]
        public string ImagenUrl { get; set; }

        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public ICollection<PeliculaGenero> PeliculaGeneros { get; set; }
        public ICollection<PeliculaActor> PeliculaActores { get; set; }

        // RCC Relationships
    }
} 