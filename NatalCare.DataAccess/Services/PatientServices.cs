using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel;
using static NatalCare.DataAccess.Response.ServiceResponses;

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
            var patients = await unitOfWork.Repository<Patients>()
            .GetAllAsync(p => p.StatusCode == "AC", includeProperties: "CreatedBy");
            return patients.ToList();
        }

        public async Task<Patients> GetInformation(string id)
        {
            var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == id);

            if (patient == null)
                return new Patients();

            return patient;
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
            patient.PatientID = await GeneratePatientID();
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
        public async Task<CommonResponse> Delete(string id, string userId)
        {
            if (id == null) return new CommonResponse(false, "id is null!");

            var item = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(x => x.PatientID == id);
            if (item == null) return new CommonResponse(false, "Patient record not existing.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.PatientUpdatedBy = userId;

            unitOfWork.Repository<Patients>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Patient record deleted successfully");
        }


        // HELPER
        public async Task<(int todayCount, int monthCount, int yearCount)> GetPatientCountsAsync()
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var yearStart = new DateTime(today.Year, 1, 1);

            var counts = await unitOfWork.Repository<Patients>()
                .AsQueryable()
                .Where(n => n.Created_At >= yearStart)
                .GroupBy(n => 1)
                .Select(g => new
                {
                    TodayCount = g.Count(n => n.Created_At >= today),
                    MonthCount = g.Count(n => n.Created_At >= monthStart),
                    YearCount = g.Count()
                })
                .FirstOrDefaultAsync();

            return counts != null ? (counts.TodayCount, counts.MonthCount, counts.YearCount) : (0, 0, 0);
        }
       
        private async Task<string> GeneratePatientID()
        {
            var lastPatient = await unitOfWork.Repository<Patients>()
                .AsQueryable()
                .OrderByDescending(p => p.PatientID)
                .FirstOrDefaultAsync();

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
