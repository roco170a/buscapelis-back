using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace apiPeliculas.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
} 