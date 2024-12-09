using Microsoft.AspNetCore.Mvc.Rendering;
using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

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
        // Delivery Status Excluding Referr
        Task<SelectList> GetDeliveryStatusSelectListAsync();
        // Delivery Status Including Referral
        Task<SelectList> GetDeliveryStatusSelectListAsyncExceptReferral();
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
        //Wards 
        Task<SelectList> GetWardsSelectListAsync();
        //Beds 
        Task<SelectList> GetBedsSelectListAsync(int? wardId);
        //Bed Selected
        Task<SelectList> GetAllBedSelectListAsync(int? wardId);




    }
}
