using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IModuleAccessServices
    {
        Task<List<Role_Access>> GetAccessibleModulesByRole(IList<string> roles);
    }
}
