using apiPeliculas.Models;

namespace apiPeliculas.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPeliculaRepository Pelicula { get; }
        IRepository<Actor> Actor { get; }
        IRepository<Genero> Genero { get; }
        IRepository<PeliculaGenero> PeliculaGenero { get; }
        IRepository<PeliculaActor> PeliculaActor { get; }

        Task SaveAsync();
    }
} 