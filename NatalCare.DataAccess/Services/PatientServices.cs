using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;
using PrinceQ.DataAccess.Hubs;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly IAppUnitOfWork unitOfWork;
        private readonly IHubContext<NatalCareHub> hubContext;

        public PatientServices(IAppUnitOfWork unitOfWork, IHubContext<NatalCareHub> hubContext)
        {
            this.unitOfWork = unitOfWork;
            this.hubContext = hubContext;
        }

        //Line Statistics
        public async Task<GeneralResponse> PatientStatistics(int year, int month)
        {
            var data = await unitOfWork.Repository<Patients>().GetAllAsync(d =>
                d.Created_At.HasValue &&
                d.Created_At.Value.Year == year &&
                (month > 0 ? d.Created_At.Value.Month == month : true));

            var groupedData = data
                .GroupBy(item => item.Created_At.Value.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Data = g.Count()
                })
                .ToList();

            return new GeneralResponse(true, groupedData, "");
        }


        //Bar Statistics
        public async Task<GeneralResponse> ServicesStatistics(int year, int month)
        {
            var prenatal = await unitOfWork.Repository<Prenatal>().GetAllAsync(d =>
                d.Created_At.HasValue &&
                d.Created_At.Value.Year == year &&
                (month > 0 ? d.Created_At.Value.Month == month : true));

            var delivery = await unitOfWork.Repository<Delivery>().GetAllAsync(d =>
               d.Created_At.HasValue &&
               d.Created_At.Value.Year == year &&
               (month > 0 ? d.Created_At.Value.Month == month : true));

            var hearing = await unitOfWork.Repository<NewbornHearing>().GetAllAsync(d =>
              d.Created_At.HasValue &&
              d.Created_At.Value.Year == year &&
              (month > 0 ? d.Created_At.Value.Month == month : true));

            var screening = await unitOfWork.Repository<NewbornScreening>().GetAllAsync(d =>
              d.Created_At.HasValue &&
              d.Created_At.Value.Year == year &&
              (month > 0 ? d.Created_At.Value.Month == month : true));

            var prenatalData = prenatal
                .GroupBy(item => item.Created_At.Value.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Data = g.Count()
                })
                .ToList();

            var deliveryData = delivery
               .GroupBy(item => item.Created_At.Value.Month)
               .Select(g => new
               {
                   Month = g.Key,
                   Data = g.Count()
               })
               .ToList();

            var hearingData = hearing
              .GroupBy(item => item.Created_At.Value.Month)
              .Select(g => new
              {
                  Month = g.Key,
                  Data = g.Count()
              })
              .ToList();

            var screeningData = screening
              .GroupBy(item => item.Created_At.Value.Month)
              .Select(g => new
              {
                  Month = g.Key,
                  Data = g.Count()
              })
              .ToList();

            return new GeneralResponse(true, new { prenatalData, deliveryData, screeningData, hearingData }, "");
        }




        //Patient
        public async Task<List<Patients>> GetRecentPatientsAsync()
        {
            var patients = await unitOfWork.Repository<Patients>().AsQueryable()
                .OrderByDescending(p => p.Created_At ?? DateTime.MinValue)
                .ThenByDescending(p => p.Updated_At ?? DateTime.MinValue)
                .Take(10)
                .Include(p => p.CreatedBy) 
                .ToListAsync();

            return patients;
        }

        public async Task<List<Patients>> GetPatients()
        {
            var patients = await unitOfWork.Repository<Patients>()
            .GetAllAsync(includeProperties: "CreatedBy,Status");
            //.GetAllAsync(p => p.StatusCode == "AC", includeProperties: "CreatedBy,Status");
            return patients.ToList();
        }
        public async Task<List<Patients>> GetDeletedPatients()
        {
            var patients = await unitOfWork.Repository<Patients>()
            .GetAllAsync(p => p.StatusCode == "IN", includeProperties: "CreatedBy");
            return patients.ToList();
        }

        public async Task<Patients> GetInformation(string id)
        {
            var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == id, includeProperties: "Spouse");

            if (patient == null)
                return new Patients();

            return patient;
        }

        //Patient Operations
        public async Task<bool> Create(Patients patient, string userId)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient), "Record cannot be null.");
            // Validation checks
            if (await unitOfWork.Repository<Patients>().AnyAsync(x => x.PatientID == patient.PatientID))
                throw new ArgumentException("Record already exists!");

            // Generate a new PatientID
            patient.PatientID = await GeneratePatientID();
            patient.Created_At = DateTime.Now;
            patient.StatusCode = "AC";
            patient.PatientCreatedBy = userId;

            unitOfWork.Repository<Patients>().Add(patient);
            if(patient.SpouseId != null)
            {
                unitOfWork.Repository<Spouse>().Add(patient.Spouse);
            }
            return await unitOfWork.Complete() > 0;
        }
        public async Task<Patients> Edit(string id, string userId)
        {
            var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == id, includeProperties: "Spouse");

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
            var existingSpouse = await unitOfWork.Repository<Spouse>().GetFirstOrDefaultAsync(p => p.SpouseId == patient.SpouseId);

            if (existingPatient == null)
                throw new KeyNotFoundException("Patient not found.");

            // Update the existing patient's properties
            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.MiddleName = patient.MiddleName;
            existingPatient.Gender = patient.Gender;
            existingPatient.Address = patient.Address;
            existingPatient.CivilStatus = patient.CivilStatus;
            existingPatient.Birthdate = patient.Birthdate;
            existingPatient.Occupation = patient.Occupation;
            existingPatient.MobileNumber = patient.MobileNumber;
            existingPatient.TeleNumber = patient.TeleNumber;
            existingPatient.Religion = patient.Religion;
            existingPatient.Nationality = patient.Nationality;
            existingPatient.BloodType = patient.BloodType;
            existingPatient.PlaceOfBirth = patient.PlaceOfBirth;
            existingPatient.Emergency_Name = patient.Emergency_Name;
            existingPatient.Emergency_MobileNumber = patient.Emergency_MobileNumber;
            existingPatient.StatusCode = patient.StatusCode;

            // Update Spouse
            if(existingSpouse.SpouseId != null)
            {
                existingSpouse.FirstName = patient.Spouse.FirstName;
                existingSpouse.MiddleName = patient.Spouse.MiddleName;
                existingSpouse.LastName = patient.Spouse.LastName;
                existingSpouse.Birthdate = patient.Spouse.Birthdate;
                existingSpouse.Gender = patient.Spouse.Gender;
                existingSpouse.Address = patient.Spouse.Address;
                existingSpouse.Occupation = patient.Spouse.Occupation;
                existingSpouse.Nationality = patient.Spouse.Nationality;
            }
           

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

        public async Task<CommonResponse> ClearSpouse(int id)
        {
            var spouse = await unitOfWork.Repository<Spouse>().GetFirstOrDefaultAsync(x => x.SpouseId == id);
            if (spouse == null)
                return new CommonResponse(false, "Spouse record not existing.");

            spouse.FirstName = null;
            spouse.MiddleName = null;
            spouse.LastName = null;
            spouse.Birthdate = null;
            spouse.Gender = null;
            spouse.Address = null;
            spouse.Occupation = null;
            spouse.Nationality = null;

            unitOfWork.Repository<Spouse>().Update(spouse);
            await unitOfWork.SaveAsync(); 

            return new CommonResponse(true, "Spouse record deleted successfully.");
        }



        // HELPER
        //public async Task<(int todayCount, int monthCount, int yearCount, int totalCount)> GetPatientCountsAsync()
        //{
        //    var today = DateTime.Today;
        //    var monthStart = new DateTime(today.Year, today.Month, 1);
        //    var yearStart = new DateTime(today.Year, 1, 1);

        //    var counts = await unitOfWork.Repository<Patients>()
        //        .AsQueryable()
        //        .Where(n => n.Created_At >= yearStart)
        //        .GroupBy(n => 1)
        //        .Select(g => new
        //        {
        //            TodayCount = g.Count(n => n.Created_At >= today),
        //            MonthCount = g.Count(n => n.Created_At >= monthStart),
        //            YearCount = g.Count(),
        //        })
        //        .FirstOrDefaultAsync();

        //    return counts != null ? (counts.TodayCount, counts.MonthCount, counts.YearCount, totalCount) : (0, 0, 0, 0);
        //}

        public async Task<(int todayCount, int monthCount, int yearCount, int TotalCount, int activeCount, int inactiveCount)> GetPatientCountsAsync()
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var yearStart = new DateTime(today.Year, 1, 1);

            var counts = await unitOfWork.Repository<Patients>()
                .AsQueryable()
                .GroupBy(n => 1)
                .Select(g => new
                {
                    // Count of patients created today
                    TodayCount = g.Count(n => n.Created_At >= today),
                    // Count of patients created this month
                    MonthCount = g.Count(n => n.Created_At >= monthStart),
                    // Count of patients created this year
                    YearCount = g.Count(n => n.Created_At >= yearStart),
                    // Count of all active patients (regardless of creation date)
                    ActiveCount = g.Count(n => n.StatusCode == "AC"),
                    InactiveCount = g.Count(n => n.StatusCode == "IN"),
                    TotalCount = g.Count(),
                })
                .FirstOrDefaultAsync();

            // If counts are found, return the count values, else return zeros
            return counts != null ? (counts.TodayCount, counts.MonthCount, counts.YearCount, counts.TotalCount ,counts.ActiveCount, counts.InactiveCount) : (0, 0, 0, 0, 0, 0);
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

        public async Task<CommonResponse> RetrievedAync(string id, string userId)
        {
            var record = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(p => p.PatientID == id);
            if (record == null)
            {
                return new CommonResponse(false, "Record Not Found.");
            }
            record.StatusCode = "AC";
            record.PatientUpdatedBy = userId;
            record.Updated_At = DateTime.Now;

            unitOfWork.Repository<Patients>().Update(record);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record Retrieved Successfully.");
        }
    }
}
