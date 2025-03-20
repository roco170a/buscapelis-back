using apiPeliculas.Models;

namespace apiPeliculas.Repository.IRepository
{
    public interface IPeliculaRepository : IRepository<Pelicula>
    {
        Task<IEnumerable<Pelicula>> BuscarPorTitulo(string titulo);
        Task<IEnumerable<Pelicula>> BuscarPorGenero(int generoId);
        Task<IEnumerable<Pelicula>> BuscarPorActor(int actorId);
        Task<IEnumerable<Pelicula>> BuscarPorCriterios(string busqueda);
    }
} 