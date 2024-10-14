
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IPatientServices
    {
        Task<List<Patients>> GetPatients();
        Task<bool> Create(Patients patient, string userId);

    }
}
