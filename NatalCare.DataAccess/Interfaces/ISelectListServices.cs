using Microsoft.AspNetCore.Mvc.Rendering;

namespace NatalCare.DataAccess.Interfaces
{
    public interface ISelectListServices
    {
        Task<SelectList> GetRoleStaffSelectListAsync();
        Task<SelectList> GetStatusCodeSelectListAsync();


        Task<SelectList> GetAllStaffSelectListAsync();
        Task<SelectList> GetStaffSelectListAsync();
        Task<SelectList> GetPhysicianSelectListAsync();
        Task<SelectList> GetMidwifeSelectListAsync();
        Task<SelectList> GetNurseSelectListAsync();
        Task<SelectList> GetDoctorSelectListAsync();

    }
}
