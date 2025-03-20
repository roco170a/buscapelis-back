using apiPeliculas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace apiPeliculas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<PeliculaGenero> PeliculaGeneros { get; set; }
        public DbSet<PeliculaActor> PeliculaActores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necesario para Identity

            // Configuración de clave primaria compuesta para PeliculaGenero
            modelBuilder.Entity<PeliculaGenero>()
                .HasKey(pg => new { pg.PeliculaId, pg.GeneroId });

            // Configuración de clave primaria compuesta para PeliculaActor
            modelBuilder.Entity<PeliculaActor>()
                .HasKey(pa => new { pa.PeliculaId, pa.ActorId });

            // Borrado en cascada
            modelBuilder.Entity<PeliculaGenero>()
                .HasOne(pg => pg.Pelicula)
                .WithMany(p => p.PeliculaGeneros)
                .HasForeignKey(pg => pg.PeliculaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PeliculaGenero>()
                .HasOne(pg => pg.Genero)
                .WithMany(g => g.PeliculaGeneros)
                .HasForeignKey(pg => pg.GeneroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PeliculaActor>()
                .HasOne(pa => pa.Pelicula)
                .WithMany(p => p.PeliculaActores)
                .HasForeignKey(pa => pa.PeliculaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PeliculaActor>()
                .HasOne(pa => pa.Actor)
                .WithMany(a => a.PeliculaActores)
                .HasForeignKey(pa => pa.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 