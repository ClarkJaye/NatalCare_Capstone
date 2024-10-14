using Microsoft.Data.SqlClient;
using NatalCare.DataAccess.Entities;

namespace NatalCare.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        Task<int> Complete();
        void Dispose();
        Task<bool> ExecuteProcedureAsync(string command, IEnumerable<SqlParameter>? parameters = null);
        Task<IEnumerable<TResult>> ExecuteProcedureAsync<TResult>(string command, IEnumerable<SqlParameter>? parameters = null);
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    }
}
