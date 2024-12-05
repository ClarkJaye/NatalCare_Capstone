using NatalCare.DataAccess.Repository;
using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IPatientServices
    {
        //Statistics
        Task<GeneralResponse> PatientStatistics(int year, int month);
        Task<GeneralResponse> ServicesStatistics(int year, int month);

        //Patient Info
        Task<Patients> GetInformation(string id);
        Task<List<Patients>> GetRecentPatientsAsync();
        Task<List<Patients>> GetPatients();
        Task<List<Patients>> GetDeletedPatients();
        Task<bool> Create(Patients patient, string userId);
        Task<Patients> Edit(string id, string userId);
        Task<bool> Update(Patients patient, string userId);
        Task<CommonResponse> Delete(string id, string userId);
        Task<CommonResponse> ClearSpouse(int id);
        Task<CommonResponse> RetrievedAync(string id, string userId);

        //ViewBag
        Task<(int todayCount, int monthCount, int yearCount, int TotalCount, int activeCount, int inactiveCount)> GetPatientCountsAsync();
    }
}
