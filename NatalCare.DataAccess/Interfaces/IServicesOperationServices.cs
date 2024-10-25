using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IServicesOperationServices
    {
        //------ PRENATAL ------//
        Task<CommonResponse> AddPrenatalRecordAsync(Prenatal prenatal, string patientId, string userId);
        Task<CommonResponse> DeletePrenatalRecordAsync(string caseNo, string userId);
        Task<GeneralResponse> GetPrenatalRecordAsync(string caseNo);
        Task<CommonResponse> UpdatePrenatalRecordAsync(Prenatal prenatal, string userId);

        //------ PRENATAL VISIT ------//
        Task<CommonResponse> AddPrenatalVisitRecordAsync(PrenatalVisit prenatalvisit, string patientId, string caseNo, string userId);
        Task<GeneralResponse> GetPrenatalVisitRecordAsync(string caseNo);
        Task<CommonResponse> UpdatePrenatalVisitRecordAsync(PrenatalVisit prenatal, string userId);
        Task<CommonResponse> DeletePrenatalVisitRecordAsync(string caseNo, string userId);



    }
}
