using apiPeliculas.Data;
using apiPeliculas.Models;
using apiPeliculas.Repository.IRepository;

namespace apiPeliculas.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Pelicula = new PeliculaRepository(_db);
            Actor = new Repository<Actor>(_db);
            Genero = new Repository<Genero>(_db);
            PeliculaGenero = new Repository<PeliculaGenero>(_db);
            PeliculaActor = new Repository<PeliculaActor>(_db);
        }

        public IPeliculaRepository Pelicula { get; private set; }
        public IRepository<Actor> Actor { get; private set; }
        public IRepository<Genero> Genero { get; private set; }
        public IRepository<PeliculaGenero> PeliculaGenero { get; private set; }
        public IRepository<PeliculaActor> PeliculaActor { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
} 