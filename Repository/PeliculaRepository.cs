using apiPeliculas.Data;
using apiPeliculas.Models;
using apiPeliculas.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace apiPeliculas.Repository
{
    public class PeliculaRepository : Repository<Pelicula>, IPeliculaRepository
    {
        private readonly ApplicationDbContext _db;

        public PeliculaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorTitulo(string titulo)
        {
            IQueryable<Pelicula> query = _db.Peliculas;

            if (!string.IsNullOrEmpty(titulo))
            {
                query = query.Where(p => p.Titulo.Contains(titulo));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorGenero(int generoId)
        {
            return await _db.Peliculas
                .Where(p => p.PeliculaGeneros.Any(pg => pg.GeneroId == generoId))
                .Include(p => p.PeliculaGeneros)
                    .ThenInclude(pg => pg.Genero)
                .Include(p => p.PeliculaActores)
                    .ThenInclude(pa => pa.Actor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorActor(int actorId)
        {
            return await _db.Peliculas
                .Where(p => p.PeliculaActores.Any(pa => pa.ActorId == actorId))
                .Include(p => p.PeliculaGeneros)
                    .ThenInclude(pg => pg.Genero)
                .Include(p => p.PeliculaActores)
                    .ThenInclude(pa => pa.Actor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pelicula>> BuscarPorCriterios(string busqueda)
        {
            if (string.IsNullOrEmpty(busqueda))
                return await _db.Peliculas
                    .Include(p => p.PeliculaGeneros)
                        .ThenInclude(pg => pg.Genero)
                    .Include(p => p.PeliculaActores)
                        .ThenInclude(pa => pa.Actor)
                    .ToListAsync();

            // RCC Search by title, genre or actor
            return await _db.Peliculas
                .Where(p => p.Titulo.Contains(busqueda) ||
                            p.PeliculaGeneros.Any(pg => pg.Genero.Nombre.Contains(busqueda)) ||
                            p.PeliculaActores.Any(pa => pa.Actor.Nombre.Contains(busqueda)))
                .Include(p => p.PeliculaGeneros)
                    .ThenInclude(pg => pg.Genero)
                .Include(p => p.PeliculaActores)
                    .ThenInclude(pa => pa.Actor)
                .ToListAsync();
        }
    }
} 