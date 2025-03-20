using System.ComponentModel.DataAnnotations.Schema;

namespace apiPeliculas.Models
{
    public class PeliculaGenero
    {
        [ForeignKey("PeliculaId")]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [ForeignKey("GeneroId")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
} 