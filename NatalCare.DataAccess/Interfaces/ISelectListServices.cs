using Microsoft.AspNetCore.Mvc.Rendering;

namespace NatalCare.DataAccess.Interfaces
{
    public interface ISelectListServices
    {
        //Newborn
        Task<SelectList> GetAllNewbornSelectListAsync(string patientId);
        //Prenatal
        Task<SelectList> GetAllPrenatalSelectListAsync(string patientId);
        //Role Staff 
        Task<SelectList> GetRoleStaffSelectListAsync();
        //Status Code 
        Task<SelectList> GetStatusCodeSelectListAsync();
        // Delivery Status 
        Task<SelectList> GetDeliveryStatusSelectListAsync();
        //All Staff Role
        Task<SelectList> GetAllStaffSelectListAsync();
        //Staff 
        Task<SelectList> GetStaffSelectListAsync();
        //Physician 
        Task<SelectList> GetPhysicianSelectListAsync();
        //Midwife 
        Task<SelectList> GetMidwifeSelectListAsync();
        //Nurse 
        Task<SelectList> GetNurseSelectListAsync();
        //Doctor 
        Task<SelectList> GetDoctorSelectListAsync();

    }
}
