using NatalCare.DataAccess.data;
using NatalCare.DataAccess.Repository;
using NatalCare.DataAccess.Repository.IRepository;

namespace NatalCare.DataAccess.Repositories
{
    public class AppUnitOfWork: UnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext context) : base(context)
        {
            
        }
    }
}
