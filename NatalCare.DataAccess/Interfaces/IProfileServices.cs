using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IProfileServices
    {
        Task<List<Role>> GetProfiles();
        Task<bool> Create(Role profile, string userId);
        Task<bool> Delete(string profileId, string userId);

        Task<Role> GetProfileById(string profileId);

        Task<bool> UpdateProfile(Role profile, string userId);
    }
}
