using NatalCare.Models.Entities;

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
        
        //ViewBag
        Task<int> GetTodayPatientCount();
        Task<int> GetMonthlyPatientCount();
        Task<int> GetYearlyPatientCount();


        //Prenatal Services
        Task<Prenatal> GetPrenatalRecord(string id);
        Task<List<Prenatal>> GetPrenatalRecords(string patientId);
        Task<List<PrenatalVisit>> GetPrenatalVisitsRecords(string caseNo, string patientId);


    }
}
