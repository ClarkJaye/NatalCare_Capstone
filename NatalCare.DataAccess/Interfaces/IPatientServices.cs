using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IPatientServices
    {
        //Patient Info
        Task<Patients> GetInformation(string id);

        Task<List<Patients>> GetPatients();
        Task<bool> Create(Patients patient, string userId);
        Task<Patients> Edit(string id, string userId);
        Task<bool> Update(Patients patient, string userId);
        Task<CommonResponse> Delete(string id, string userId);

        //ViewBag
        Task<(int todayCount, int monthCount, int yearCount)> GetPatientCountsAsync();
    }
}
