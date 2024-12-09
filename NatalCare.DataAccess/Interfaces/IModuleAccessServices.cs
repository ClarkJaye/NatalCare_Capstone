using Microsoft.AspNetCore.Identity;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IModuleAccessServices
    {
        Task<bool> HasAccessToModule(string roleId, int moduleId);
        Task<List<Role_Access>> GetAccessibleModulesByRole(IList<string> roles);

        UserManager<User> UserManager { get; }
        RoleManager<Role> RoleManager { get; }
    }
}
