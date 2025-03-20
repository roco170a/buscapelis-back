using System.ComponentModel.DataAnnotations;

namespace apiPeliculas.DTOs
{
    public class PeliculaDTO
    {
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

        public List<PeliculaGeneroDTO> Generos { get; set; }
        public List<PeliculaActorDTO> Actores { get; set; }
    }
} 