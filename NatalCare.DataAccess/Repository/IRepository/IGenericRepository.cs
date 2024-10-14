using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace NatalCare.DataAccess.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> AsQueryable();
        Task<int> CountAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = true, bool ignoreQueryFilter = false);

        Task<IEnumerable<T>> GetAllAsync2(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracked = true, bool ignoreQueryFilter = false );

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true, bool ignoreQueryFilter = false);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity);
    }
}
