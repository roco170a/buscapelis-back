using System.Linq.Expressions;

namespace apiPeliculas.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = null);
        
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, 
            string includeProperties = null);
        
        Task<T> GetByIdAsync(int id);
        
        Task AddAsync(T entity);
        
        Task RemoveAsync(T entity);
        
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
} 