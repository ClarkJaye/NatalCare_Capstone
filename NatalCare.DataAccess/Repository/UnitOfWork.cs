using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Entities;
using NatalCare.DataAccess.Repositories;
using NatalCare.DataAccess.Repository.IRepository;
using System.Collections;

namespace NatalCare.DataAccess.Repository
{
    internal class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TResult>> ExecuteProcedureAsync<TResult>(string command, IEnumerable<SqlParameter>? parameters = null)
        {
            if (parameters == null)
                return await _dbContext.Database.SqlQueryRaw<TResult>(command).ToListAsync();

            return await _dbContext.Database.SqlQueryRaw<TResult>(command, parameters.ToArray()).ToListAsync();
        }

        public async Task<bool> ExecuteProcedureAsync(string command, IEnumerable<SqlParameter>? parameters = null)
        {
            if (parameters == null)
                return await _dbContext.Database.ExecuteSqlRawAsync(command) > 0;

            return await _dbContext.Database.ExecuteSqlRawAsync(command, parameters.ToArray()) > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();
            var Type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(Type))
            {
                var repositiryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositiryType.MakeGenericType(typeof(TEntity)), _dbContext);
                _repositories.Add(Type, repositoryInstance);
            }
            return (IGenericRepository<TEntity>)_repositories[Type];
        }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
