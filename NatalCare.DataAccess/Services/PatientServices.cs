using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Services
{
    internal class PatientServices : IPatientServices
    {
        private readonly IAppUnitOfWork unitOfWork;

        public PatientServices(IAppUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Patients>> GetPatients()
        {
            var patients = await unitOfWork.Repository<Patients>().GetAllAsync();
            return patients.ToList();
        }

        public async Task<bool> Create(Patients patient, string userId)
        {
            // Generate a new PatientID
            patient.PatientID = GeneratePatientID();

            if (await unitOfWork.Repository<Patients>().AnyAsync(x => x.PatientID == patient.PatientID))
                throw new ArgumentException("Patient already exists!");

            patient.Created_At = DateTime.Now;
            patient.StatusCode = "AC";
            patient.PatientCreatedBy = userId;

            unitOfWork.Repository<Patients>().Add(patient);

            return await unitOfWork.Complete() > 0;
        }

        private string GeneratePatientID()
        {
            // Retrieve the last patient ID, if available
            var lastPatient = unitOfWork.Repository<Patients>()
                .AsQueryable()
                .OrderByDescending(p => p.PatientID)
                .FirstOrDefault();

            int newIdNumber = 1; // Start at 1 if no patients are found

            if (lastPatient != null && lastPatient.PatientID != null)
            {
                // Extract numeric part and increment
                string numericPart = lastPatient.PatientID.Substring(2); // "PT" is 2 characters
                newIdNumber = int.Parse(numericPart) + 1;
            }

            // Dynamically adjust the length of the numeric part based on the number (e.g., PT0001, PT0010, PT0100, PT1000)
            return $"PT{newIdNumber:D4}"; // Formats as PT0001, PT0010, etc.
        }
    }
}
