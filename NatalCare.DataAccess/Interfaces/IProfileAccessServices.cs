using NatalCare.Models.DTOs;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IProfileAccessServices
    {
        Task<(Role, List<Role_Access>)> GetProfileAndAccessById(string profileId);

        Task UpdateAccess(List<Role_Access> profileAccessList);
    }
}
