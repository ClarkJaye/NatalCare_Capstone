using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IServicesOperationServices
    {
        //------ PRENATAL ------//
        Task<Prenatal> GetPrenatalRecord(string id, string caseno);
        Task<List<Prenatal>> GetDeletedPrenatalRecords(string patientId);
        Task<List<Prenatal>> GetPrenatalRecords(string patientId);
        //CRUD
        Task<CommonResponse> AddPrenatalRecordAsync(Prenatal prenatal, string patientId, string userId);
        Task<CommonResponse> DeletePrenatalRecordAsync(string caseNo, string userId);
        Task<GeneralResponse> GetPrenatalRecordAsync(string caseNo);
        Task<CommonResponse> UpdatePrenatalRecordAsync(Prenatal prenatal, string userId);

        //------ PRENATAL VISIT ------//
        Task<List<PrenatalVisit>> GetPrenatalVisitsRecords(string caseNo, string patientId);
        //CRUD
        Task<CommonResponse> AddPrenatalVisitRecordAsync(PrenatalVisit prenatalvisit, string patientId, string caseNo, string userId);
        Task<GeneralResponse> GetPrenatalVisitRecordAsync(string caseNo);
        Task<CommonResponse> UpdatePrenatalVisitRecordAsync(PrenatalVisit prenatal, string userId);
        Task<CommonResponse> DeletePrenatalVisitRecordAsync(string caseNo, string userId);
        Task<CommonResponse> RetrievedPrenetalAync(string caseno, string userId);

        //------ FAMILY PLANNING ------//
        Task<List<FamilyPlanning>> GetFamilyPlanningRecords(string patientId);
        Task<List<FamilyPlanning>> GetDeletedFPRecords(string patientId);
        //CRUD
        Task<CommonResponse> AddFPRecordAsync(FamilyPlanning fp, string patientId, string userId);
        Task<GeneralResponse> GetFPRecordAsync(string caseNo);
        Task<CommonResponse> UpdateFPRecordAsync(FamilyPlanning fp, string userId);
        Task<CommonResponse> DeleteFPRecordAsync(string caseNo, string userId);
        Task<CommonResponse> RetrievedFPAync(string caseno, string userId);


    }
}
