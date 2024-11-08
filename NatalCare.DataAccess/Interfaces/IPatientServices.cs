using NatalCare.DataAccess.Repository;
using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IPatientServices
    {
        //Patient Info
        Task<Patients> GetInformation(string id);

        Task<List<Patients>> GetPatients();
        Task<List<Patients>> GetDeletedPatients();
        Task<bool> Create(Patients patient, string userId);
        Task<bool> CreateSpouse(Spouse spouse);
        Task<Patients> Edit(string id, string userId);
        Task<bool> Update(Patients patient, string userId);
        Task<CommonResponse> Delete(string id, string userId);
        Task<CommonResponse> RetrievedAync(string id, string userId);

        //ViewBag
        Task<(int todayCount, int monthCount, int yearCount)> GetPatientCountsAsync();
    }
}
