using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IProfileServices
    {
        Task<List<Role>> GetProfiles();
        Task<bool> Create(Role profile, string userId);
        Task<bool> Delete(string profileId, string userId);

        Task<Role> GetProfileById(string profileId);

        Task<bool> UpdateProfile(Role profile, string userId);

        //STAFF
        Task<List<Staff>> GetAllStaff();
        Task<CommonResponse> DeleteStaff(int id);
        Task<bool> CreateStaff(Staff staff);
        Task<Staff> GetStaffById(int id);
        Task<bool> UpdateStaff(Staff staff);


    }
}
