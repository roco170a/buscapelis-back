using System.ComponentModel.DataAnnotations.Schema;

namespace apiPeliculas.Models
{
    public class PeliculaActor
    {
        [ForeignKey("PeliculaId")]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [ForeignKey("ActorId")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public string Personaje { get; set; }
    }
} 