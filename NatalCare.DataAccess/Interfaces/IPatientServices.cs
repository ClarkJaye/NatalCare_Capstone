using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IPatientServices
    {
        Task<Patients> GetInformation(string id);
        Task<Patients> GetMedicalRecords(string id);


        Task<List<Patients>> GetPatients();
        Task<bool> Create(Patients patient, string userId);
        Task<Patients> Edit(string id, string userId);
        Task<bool> Update(Patients patient, string userId);


        Task<int> GetTodayPatientCount();
        Task<int> GetMonthlyPatientCount();
        Task<int> GetYearlyPatientCount();

    }
}
