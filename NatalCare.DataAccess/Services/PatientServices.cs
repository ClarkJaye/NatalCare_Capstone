using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel;

namespace NatalCare.DataAccess.Services
{
    internal class PatientServices : IPatientServices
    {
        private readonly IAppUnitOfWork unitOfWork;

        public PatientServices(IAppUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //Patient
        public async Task<List<Patients>> GetPatients()
        {
            var patients = await unitOfWork.Repository<Patients>().GetAllAsync();
            return patients.ToList();
        }

        public async Task<Patients> GetInformation(string id)
        {
            var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == id);

            if (patient == null)
                throw new KeyNotFoundException("Patient not found.");

            return patient;
        }



        //Services
        public async Task<List<Prenatal>> GetPrenatalRecords(string patientId)
        {
            var record = await unitOfWork.Repository<Prenatal>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "AC");
            if (!record.Any()) 
            {
                return new List<Prenatal>(); 
            }
            return record.ToList();
        }

        public async Task<Prenatal> GetPrenatalRecord(string patientId)
        {
            var record = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(p => p.PatientID == patientId);
            if (record == null)
            {
                return new Prenatal();
            }
            return record;
        }
        public async Task<List<PrenatalVisit>> GetPrenatalVisitsRecords(string caseNo, string patientId)
        {
            var record = await unitOfWork.Repository<PrenatalVisit>().GetAllAsync(p => p.CaseNo == caseNo && p.PatientID == patientId && p.StatusCode == "AC");
            if (!record.Any())
            {
                return new List<PrenatalVisit>();
            }
            return record.ToList();
        }




        //Patient Operations
        public async Task<bool> Create(Patients patient, string userId)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");

            // Validation checks
            if (await unitOfWork.Repository<Patients>().AnyAsync(x => x.PatientID == patient.PatientID))
                throw new ArgumentException("Patient already exists!");

            // Generate a new PatientID
            patient.PatientID = GeneratePatientID();
            patient.Created_At = DateTime.Now;
            patient.StatusCode = "AC";
            patient.PatientCreatedBy = userId;

            unitOfWork.Repository<Patients>().Add(patient);
            return await unitOfWork.Complete() > 0;
        }
        public async Task<Patients> Edit(string id, string userId)
        {
            var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == id);

            if (patient == null)
                throw new KeyNotFoundException("Patient not found.");

            return patient;
        }
        public async Task<bool> Update(Patients patient, string userId)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");

            // Retrieve the existing patient record from the database
            var existingPatient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == patient.PatientID);

            if (existingPatient == null)
                throw new KeyNotFoundException("Patient not found.");

            // Update the existing patient's properties
            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.MiddleName = patient.MiddleName;
            existingPatient.Gender = patient.Gender;
            existingPatient.Address = patient.Address;
            existingPatient.CivilStatus = patient.CivilStatus;
            existingPatient.Occupation = patient.Occupation;
            existingPatient.MobileNumber = patient.MobileNumber;
            existingPatient.TeleNumber = patient.TeleNumber;
            existingPatient.Religion = patient.Religion;
            existingPatient.BloodType = patient.BloodType;
            existingPatient.PlaceOfBirth = patient.PlaceOfBirth;
            existingPatient.Emergency_Name = patient.Emergency_Name;
            existingPatient.Emergency_Contact = patient.Emergency_Contact;
            existingPatient.StatusCode = patient.StatusCode;

            if (patient.HasPhilHealth == true)
            {
                existingPatient.HasPhilHealth = patient.HasPhilHealth;
                existingPatient.PHIC_NO = patient.PHIC_NO;
            }
            else
            {
                existingPatient.HasPhilHealth = false;
                existingPatient.PHIC_NO = null;
            }

            existingPatient.PatientUpdatedBy = userId;
            existingPatient.Updated_At = DateTime.Now;

          

            // Update the patient in the repository
            unitOfWork.Repository<Patients>().Update(existingPatient);
            return await unitOfWork.Complete() > 0;
        }


        // HELPER
        public async Task<int> GetTodayPatientCount()
        {
            var today = DateTime.Today;
            return await unitOfWork.Repository<Patients>()
                .AsQueryable()
                .CountAsync(p => p.Created_At >= today && p.Created_At < today.AddDays(1));
        }
        public async Task<int> GetMonthlyPatientCount()
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var startOfNextMonth = startOfMonth.AddMonths(1);
            return await unitOfWork.Repository<Patients>()
                .AsQueryable()
                .CountAsync(p => p.Created_At >= startOfMonth && p.Created_At < startOfNextMonth);
        }
        public async Task<int> GetYearlyPatientCount()
        {
            var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            var startOfNextYear = startOfYear.AddYears(1);
            return await unitOfWork.Repository<Patients>()
                .AsQueryable()
                .CountAsync(p => p.Created_At >= startOfYear && p.Created_At < startOfNextYear);
        }
        private string GeneratePatientID()
        {
            var lastPatient = unitOfWork.Repository<Patients>()
                .AsQueryable()
                .OrderByDescending(p => p.PatientID)
                .FirstOrDefault();

            int newIdNumber = 1; // Start at 1 if no patients are found

            if (lastPatient != null && lastPatient.PatientID != null)
            {
                string numericPart = lastPatient.PatientID.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }

            return $"PT{newIdNumber:D4}"; // Formats as PT0001, PT0010, etc.
        }

    }
}
