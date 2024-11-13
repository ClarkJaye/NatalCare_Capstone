using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Services
{
    internal class ServicesOperationServices : IServicesOperationServices
    {
        private readonly IAppUnitOfWork unitOfWork;

        public ServicesOperationServices(IAppUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // Prenatal 
        public async Task<GeneralResponse> GetPrenatalFormRecordAsync(string id)
        {
            if (id == null) return new GeneralResponse(false, null, "No Record found");
            var record1 = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(p => p.CaseNo == id, includeProperties: "Patient");
            var record2 = await unitOfWork.Repository<PrenatalVisit>().GetAllAsync(p => p.CaseNo == record1.CaseNo);

            return new GeneralResponse(true, new { prenatalRecord = record1, prenatalVisit = record2 }, "Successfulldy retrieve");
        }
        public async Task<Prenatal> GetPrenatalRecord(string patientId, string caseno)
        {
            var record = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == caseno);
            if (record == null)
            {
                return new Prenatal();
            }
            return record;
        }
        public async Task<List<Prenatal>> GetDeletedPrenatalRecords(string patientId)
        {
            var record = await unitOfWork.Repository<Prenatal>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "DL");
            if (!record.Any())
            {
                return new List<Prenatal>();
            }
            return record.ToList();
        }
        public async Task<List<Prenatal>> GetPrenatalRecords(string patientId)
        {
            var record = await unitOfWork.Repository<Prenatal>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "AC");
            if (!record.Any())
            {
                return new List<Prenatal>();
            }
            return record.ToList();
        }
        public async Task<CommonResponse> AddPrenatalRecordAsync(Prenatal prenatal, string patientId, string userId)
        {
            if (prenatal == null)
                return new CommonResponse(false, "Prenatal cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<Prenatal>().AnyAsync(x => x.CaseNo == prenatal.CaseNo))
                return new CommonResponse(false, "Prenatal record already exists.");

            // Generate a new CaseNo for the record.
            prenatal.CaseNo = GeneratePrenatalID();
            prenatal.PatientID = patientId;
            prenatal.Created_At = DateTime.Now;
            prenatal.StatusCode = "AC";
            prenatal.PrenatalCreatedBy = userId;

            unitOfWork.Repository<Prenatal>().Add(prenatal);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal record added successfully");
        }
        public async Task<GeneralResponse> GetPrenatalRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Case No cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new GeneralResponse(false, item, "Prenatal record not existing.");

            return new GeneralResponse(true, item, "Prenatal record fetched successfully!.");
        }
        public async Task<CommonResponse> UpdatePrenatalRecordAsync(Prenatal prenatal, string userId)
        {
            var existingRecord = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(p => p.CaseNo == prenatal.CaseNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Prenatal record not found.");

            // Update the existing record fields
            existingRecord.Gravida = prenatal.Gravida;
            existingRecord.Para = prenatal.Para;
            existingRecord.Abortion = prenatal.Abortion;
            existingRecord.StillBirth = prenatal.StillBirth;
            existingRecord.LMP = prenatal.LMP;
            existingRecord.EDC = prenatal.EDC;
            existingRecord.DateVisit = prenatal.DateVisit;
            existingRecord.HRCODE = prenatal.HRCODE;
            existingRecord.Notes = prenatal.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.PrenatalUpdatedBy = userId;

            unitOfWork.Repository<Prenatal>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal record updated successfully.");
        }
        public async Task<CommonResponse> DeletePrenatalRecordAsync(string caseNo, string userId)
        {
            if (caseNo == null)
                return new CommonResponse(false, "CaseNo cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Prenatal record not found.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.PrenatalUpdatedBy = userId;

            var item2 = await unitOfWork.Repository<PrenatalVisit>().GetFirstOrDefaultAsync(x => x.CaseNo == item.CaseNo);
            if (item2 != null)
            {
                item2.StatusCode = "DL";
                item2.Updated_At = DateTime.Now;
                item2.PrenatalUpdatedBy = userId;
                unitOfWork.Repository<PrenatalVisit>().Update(item2);
            }
            unitOfWork.Repository<Prenatal>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal record deleted successfully");
        }
        public async Task<CommonResponse> RetrievedPrenetalAync(string caseno, string userId)
        {
            var record = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(p => p.CaseNo == caseno);
            if (record == null)
            {
                return new CommonResponse(false, "Record Not Found.");
            }
            record.StatusCode = "AC";
            record.PrenatalUpdatedBy = userId;
            record.Updated_At = DateTime.Now;

            var item2 = await unitOfWork.Repository<PrenatalVisit>().GetFirstOrDefaultAsync(x => x.CaseNo == caseno);
            if (item2 != null)
            {
                item2.StatusCode = "AC";
                item2.Updated_At = DateTime.Now;
                item2.PrenatalUpdatedBy = userId;
                unitOfWork.Repository<PrenatalVisit>().Update(item2);
            }

            unitOfWork.Repository<Prenatal>().Update(record);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record Retrieved Successfully.");
        }
        // Prenatal Visit
        public async Task<List<PrenatalVisit>> GetPrenatalVisitsRecords(string caseNo, string patientId)
        {
            var record = await unitOfWork.Repository<PrenatalVisit>().GetAllAsync(p => p.CaseNo == caseNo && p.PatientID == patientId && p.StatusCode == "AC");
            if (!record.Any())
            {
                return new List<PrenatalVisit>();
            }
            return record.ToList();
        }
        public async Task<CommonResponse> AddPrenatalVisitRecordAsync(PrenatalVisit prenatalvisit, string patientId, string caseNo, string userId)
        {
            if (prenatalvisit == null)
                return new CommonResponse(false, "Record cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<PrenatalVisit>().AnyAsync(x => x.PrenatalVisitID == prenatalvisit.PrenatalVisitID))
                return new CommonResponse(false, "Record already exists.");

            // Generate a new CaseNo for the record.
            prenatalvisit.CaseNo = caseNo;
            prenatalvisit.PatientID = patientId;
            prenatalvisit.Created_At = DateTime.Now;
            prenatalvisit.StatusCode = "AC";
            prenatalvisit.PrenatalCreatedBy = userId;

            unitOfWork.Repository<PrenatalVisit>().Add(prenatalvisit);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record added successfully");
        }
        public async Task<GeneralResponse> GetPrenatalVisitRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Record cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<PrenatalVisit>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new GeneralResponse(false, null, "Prenatal Visit record not existing.");

            return new GeneralResponse(true, item, "Prenatal Visit record fetched successfully!.");
        }
        public async Task<CommonResponse> UpdatePrenatalVisitRecordAsync(PrenatalVisit prenatal, string userId)
        {
            var existingRecord = await unitOfWork.Repository<PrenatalVisit>().GetFirstOrDefaultAsync(p => p.CaseNo == prenatal.CaseNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Prenatal visit record not found.");

            // Update the existing record fields
            existingRecord.AOGWeek = prenatal.AOGWeek;
            existingRecord.Weight = prenatal.Weight;
            existingRecord.BP = prenatal.BP;
            existingRecord.FH = prenatal.FH;
            existingRecord.FHT = prenatal.FHT;
            existingRecord.Temp = prenatal.Temp;
            existingRecord.DateVisit = prenatal.DateVisit;
            existingRecord.CR = prenatal.CR;
            existingRecord.RR = prenatal.RR;
            existingRecord.PhysicalAssessment = prenatal.PhysicalAssessment;
            existingRecord.Notes = prenatal.Notes;
            existingRecord.DateVisit = prenatal.DateVisit;
            existingRecord.RX = prenatal.RX;
            existingRecord.Updated_At = DateTime.Now;
            existingRecord.PrenatalUpdatedBy = userId;



            unitOfWork.Repository<PrenatalVisit>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal visit record updated successfully.");
        }
        public async Task<CommonResponse> DeletePrenatalVisitRecordAsync(string caseNo, string userId)
        {
            if (caseNo == null)
                return new CommonResponse(false, "caseNo not found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<PrenatalVisit>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Prenatal visit record not existing.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.PrenatalUpdatedBy = userId;

            unitOfWork.Repository<PrenatalVisit>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal visit record deleted successfully");
        }

        // Family Planning 
        public async Task<List<FamilyPlanning>> GetDeletedFPRecords(string patientId)
        {
            var record = await unitOfWork.Repository<FamilyPlanning>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "DL");
            if (!record.Any())
            {
                return new List<FamilyPlanning>();
            }
            return record.ToList();
        }
        public async Task<List<FamilyPlanning>> GetFamilyPlanningRecords(string patientId)
        {
            var record = await unitOfWork.Repository<FamilyPlanning>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "AC");
            if (!record.Any())
            {
                return new List<FamilyPlanning>();
            }
            return record.ToList();
        }
        public async Task<CommonResponse> AddFPRecordAsync(FamilyPlanning fp, string patientId, string userId)
        {
            if (fp == null)
                return new CommonResponse(false, "Family Planning record cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<Prenatal>().AnyAsync(x => x.CaseNo == fp.CaseNo))
                return new CommonResponse(false, "Record already exists.");

            // Generate a new CaseNo for the record.
            fp.CaseNo = GenerateFPID();
            fp.PatientID = patientId;
            fp.Created_At = DateTime.Now;
            fp.StatusCode = "AC";
            fp.FPCreatedBy = userId;

            unitOfWork.Repository<FamilyPlanning>().Add(fp);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Family Planning record added successfully");
        }
        public async Task<GeneralResponse> GetFPRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Case No cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<FamilyPlanning>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new GeneralResponse(false, item, "Family Planning record not existing.");

            return new GeneralResponse(true, item, "Family Planning record retreived successfully!.");
        }
        public async Task<CommonResponse> UpdateFPRecordAsync(FamilyPlanning fp, string userId)
        {
            var existingRecord = await unitOfWork.Repository<FamilyPlanning>().GetFirstOrDefaultAsync(p => p.CaseNo == fp.CaseNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Family Planning record not found.");

            // Update the existing record fields
            existingRecord.NoOfLivingChild = fp.NoOfLivingChild;
            existingRecord.PlanToHaveMoreChildren = fp.PlanToHaveMoreChildren;
            existingRecord.MethodType = fp.MethodType;
            existingRecord.AverageMonthlyIncome = fp.AverageMonthlyIncome;
            existingRecord.SpouseName = fp.SpouseName;
            existingRecord.SpouseOccupation = fp.SpouseOccupation;
            existingRecord.DateVisit = fp.DateVisit;
            existingRecord.Notes = fp.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.FPUpdatedBy = userId;

            unitOfWork.Repository<FamilyPlanning>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Family Planning record updated successfully.");
        }
        public async Task<CommonResponse> DeleteFPRecordAsync(string caseNo, string userId)
        {
            if (caseNo == null)
                return new CommonResponse(false, "CaseNo cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<FamilyPlanning>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Family Panning record not found.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.FPUpdatedBy = userId;

            unitOfWork.Repository<FamilyPlanning>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Family Panning record deleted successfully");
        }
        public async Task<CommonResponse> RetrievedFPAync(string caseno, string userId)
        {
            var record = await unitOfWork.Repository<FamilyPlanning>().GetFirstOrDefaultAsync(p => p.CaseNo == caseno);
            if (record == null)
            {
                return new CommonResponse(false, "Record Not Found.");
            }
            record.StatusCode = "AC";
            record.FPUpdatedBy = userId;
            record.Updated_At = DateTime.Now;

            unitOfWork.Repository<FamilyPlanning>().Update(record);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record Retrieved Successfully.");
        }

        // Newborn Hearing
        public async Task<List<NewbornHearing>> GetDeletedHRRecords(string patientId)
        {
            var record = await unitOfWork.Repository<NewbornHearing>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "DL");
            if (!record.Any())
            {
                return new List<NewbornHearing>();
            }
            return record.ToList();
        }
        public async Task<CommonResponse> RetrievedHRAync(string caseno, string userId)
        {
            var record = await unitOfWork.Repository<NewbornHearing>().GetFirstOrDefaultAsync(p => p.HearingNo == caseno);
            if (record == null)
            {
                return new CommonResponse(false, "Record Not Found.");
            }
            record.StatusCode = "AC";
            record.HearingUpdatedBy = userId;
            record.Updated_At = DateTime.Now;
            
            unitOfWork.Repository<NewbornHearing>().Update(record);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record Retrieved Successfully.");
        }
        public async Task<List<NewbornHearing>> GetHearingRecords(string patientId)
        {
            var record = await unitOfWork.Repository<NewbornHearing>()
                .GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "AC", includeProperties: "Newborn" );
            return record.ToList();
        }
        public async Task<List<Patients>> GetPatients()
        {
            var patients = await unitOfWork.Repository<Patients>()
            .GetAllAsync(p => p.StatusCode == "AC", includeProperties: "CreatedBy");
            return patients.ToList();
        }
        public async Task<GeneralResponse> Get_Newborn(string motherId)
        {
            var newborn = await unitOfWork.Repository<Newborn>()
                                           .AsQueryable()
                                           .Where(a => a.MotherID == motherId)
                                           .Select(a => new
                                           {
                                               id = a.NewbornID,
                                               firstname = a.FirstName,
                                               middlename = a.MiddleName,
                                               lastname = a.LastName,
                                               birthdate = a.DateofBirth,
                                           })
                                           .ToListAsync();

            return new GeneralResponse(true, new { newborn }, "Record fetched successfully!");
        }
        public async Task<CommonResponse> AddHRRecordAsync(NewbornHearing item, string patientId, string userId)
        {
            if (item == null)
                return new CommonResponse(false, "item cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<NewbornHearing>().AnyAsync(x => x.HearingNo == item.HearingNo))
                return new CommonResponse(false, "Newborn Hearing record already exists.");

            // Generate a new CaseNo for the record.
            item.HearingNo = GenerateHearingID();
            item.PatientID = patientId;
            item.Created_At = DateTime.Now;
            item.StatusCode = "AC";
            item.HearingCreatedBy = userId;

            unitOfWork.Repository<NewbornHearing>().Add(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Newborn Hearing record added successfully");
        }
        public async Task<CommonResponse> DeleteHRRecordAsync(string caseNo, string userId)
        {
            if (caseNo == null)
                return new CommonResponse(false, "caseNo not found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<NewbornHearing>().GetFirstOrDefaultAsync(x => x.HearingNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Record not existing.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.HearingUpdatedBy = userId;

            unitOfWork.Repository<NewbornHearing>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record deleted successfully");
        }
        public async Task<GeneralResponse> GetHRRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Case No cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<NewbornHearing>().GetFirstOrDefaultAsync(x => x.HearingNo == caseNo, includeProperties: "Newborn,Staff");
            if (item == null)
                return new GeneralResponse(false, item, "Record not existing.");

            var newborn = await unitOfWork.Repository<Newborn>()
                                           .AsQueryable()
                                           .Where(a => a.MotherID == item.PatientID)
                                           .Select(a => new
                                           {
                                               id = a.NewbornID,
                                               firstname = a.FirstName,
                                               middlename = a.MiddleName,
                                               lastname = a.LastName,
                                               birthdate = a.DateofBirth,
                                           })
                                           .ToListAsync();


            var result = new
            {
                hearingNo = item.HearingNo,
                dateVisit = item.DateVisit,
                newbornID = item.NewbornID,
                testDate = item.TestDate,
                babyStatus = item.BabyStatus,
                hearingResult = item.HearingResults,
                notes = item.Notes,
                practitioner = item.AttendingPractioner,
                patientId = item.PatientID
            };

            return new GeneralResponse(true, new { result, newborn }, "Record fetched successfully!.");
        }
        public async Task<CommonResponse> UpdateHRRecordAsync(NewbornHearing item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<NewbornHearing>().GetFirstOrDefaultAsync(p => p.HearingNo == item.HearingNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Record not found.");

            // Update the existing record fields
            existingRecord.DateVisit = item.DateVisit;
            existingRecord.NewbornID = item.NewbornID;
            existingRecord.TestDate = item.TestDate;
            existingRecord.BabyStatus = item.BabyStatus;
            existingRecord.HearingResults = item.HearingResults;
            existingRecord.Notes = item.Notes;
            existingRecord.AttendingPractioner = item.AttendingPractioner;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.HearingUpdatedBy = userId;

            unitOfWork.Repository<NewbornHearing>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record updated successfully.");
        }

        // Newborn Screening
        public async Task<List<NewbornScreening>> GetDeletedSNRecords(string patientId)
        {
            var record = await unitOfWork.Repository<NewbornScreening>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "DL");
            if (!record.Any())
            {
                return new List<NewbornScreening>();
            }
            return record.ToList();
        }
        public async Task<CommonResponse> RetrievedSNAync(string caseno, string userId)
        {
            var record = await unitOfWork.Repository<NewbornScreening>().GetFirstOrDefaultAsync(p => p.ScreeningNo == caseno);
            if (record == null)
            {
                return new CommonResponse(false, "Record Not Found.");
            }
            record.StatusCode = "AC";
            record.ScreeningUpdatedBy = userId;
            record.Updated_At = DateTime.Now;

            unitOfWork.Repository<NewbornScreening>().Update(record);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record Retrieved Successfully.");
        }
        public async Task<List<NewbornScreening>> GetScreeningRecords(string patientId)
        {
            var record = await unitOfWork.Repository<NewbornScreening>()
                .GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "AC", includeProperties: "Newborn");
            return record.ToList();
        }
        public async Task<CommonResponse> AddSNRecorddAsync(NewbornScreening item, string patientId, string userId)
        {
            if (item == null)
                return new CommonResponse(false, "item cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<NewbornScreening>().AnyAsync(x => x.ScreeningNo == item.ScreeningNo))
                return new CommonResponse(false, "Newborn Screening ecord already exists.");

            // Generate a new CaseNo for the record.
            item.ScreeningNo = GenerateScreeningID();
            item.PatientID = patientId;
            item.Created_At = DateTime.Now;
            item.StatusCode = "AC";
            item.ScreeningCreatedBy = userId;

            unitOfWork.Repository<NewbornScreening>().Add(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Newborn Screening record added successfully");
        }
        public async Task<GeneralResponse> GetScreeningRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Case No cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<NewbornScreening>().GetFirstOrDefaultAsync(x => x.ScreeningNo == caseNo, includeProperties: "Newborn,Staff");
            if (item == null)
                return new GeneralResponse(false, item, "Record not existing.");

            var staff = await unitOfWork.Repository<Staff>().GetAllAsync();
            var newborn = await unitOfWork.Repository<Newborn>()
                                           .AsQueryable()
                                           .Where(a => a.MotherID == item.PatientID)
                                           .Select(a => new
                                           {
                                               id = a.NewbornID,
                                               firstname = a.FirstName,
                                               middlename = a.MiddleName,
                                               lastname = a.LastName,
                                               birthdate = a.DateofBirth,
                                           })
                                           .ToListAsync();


            var result = new
            {
                screeningNo = item.ScreeningNo,
                dateVisit = item.DateVisit,
                dateRegistration = item.DateRegistration,
                filterCardNo = item.FilterCardNo,
                typeOfSample = item.TypeOfSample,
                dateOfCollection = item.DateOfCollection,
                timeOfCollection = item.TimeOfCollection,
                placeOfCollection = item.PlaceOfCollection,
                feeding = item.Feeding,
                specimen = item.Specimen,
                babyStatus = item.BabyStatus,
                dataSampleSent = item.DataSampleSent,
                courier = item.Courier,
                trackingNubmer = item.TrackingNubmer,
                remarks = item.Remarks,
                notes = item.Notes,
                newbornID = item.NewbornID,
                attendingPractitioner = item.AttendingPractitioner,
                patientId = item.PatientID
            };

            return new GeneralResponse(true, new { result, staff, newborn }, "Record fetched successfully!.");
        }
        public async Task<CommonResponse> DeleteScreeningRecordAsync(string caseNo, string userId)
        {
            if (caseNo == null)
                return new CommonResponse(false, "CaseNo cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<NewbornScreening>().GetFirstOrDefaultAsync(x => x.ScreeningNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Screening record not found.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.ScreeningUpdatedBy = userId;

            unitOfWork.Repository<NewbornScreening>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Screening record deleted successfully");
        }
        public async Task<CommonResponse> UpdateScreeningRecordAsync(NewbornScreening item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<NewbornScreening>().GetFirstOrDefaultAsync(p => p.ScreeningNo == item.ScreeningNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Record not found.");

            // Update the existing record fields
            existingRecord.DateVisit = item.DateVisit;
            existingRecord.DateRegistration = item.DateRegistration;
            existingRecord.TypeOfSample = item.TypeOfSample;
            existingRecord.FilterCardNo = item.FilterCardNo;
            existingRecord.DateOfCollection = item.DateOfCollection;
            existingRecord.TimeOfCollection = item.TimeOfCollection;
            existingRecord.PlaceOfCollection = item.PlaceOfCollection;
            existingRecord.Feeding = item.Feeding;
            existingRecord.Specimen = item.Specimen;
            existingRecord.BabyStatus = item.BabyStatus;
            existingRecord.ScreeningResults = item.ScreeningResults;
            existingRecord.DataSampleSent = item.DataSampleSent;
            existingRecord.Courier = item.Courier;
            existingRecord.TrackingNubmer = item.TrackingNubmer;
            existingRecord.Remarks = item.Remarks;
            existingRecord.Notes = item.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.ScreeningUpdatedBy = userId;
            existingRecord.NewbornID = item.NewbornID;
            existingRecord.AttendingPractitioner = item.AttendingPractitioner;

            unitOfWork.Repository<NewbornScreening>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record updated successfully.");
        }






        //Generation of ID's
        // Prenatal
        private string GeneratePrenatalID()
        {
            var lastPrenatal = unitOfWork.Repository<Prenatal>()
                .AsQueryable()
                .OrderByDescending(p => p.CaseNo)
                .FirstOrDefault();

            int newIdNumber = 1;

            if (lastPrenatal != null && lastPrenatal.CaseNo != null)
            {
                string numericPart = lastPrenatal.CaseNo.Substring(3);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"PRE{newIdNumber:D4}"; // Formats as PRE0001, PRE0010, etc.
        }
        // Family Planning
        private string GenerateFPID()
        {
            var lastRecord = unitOfWork.Repository<FamilyPlanning>()
                .AsQueryable()
                .OrderByDescending(p => p.CaseNo)
                .FirstOrDefault();

            int newIdNumber = 1;

            if (lastRecord != null && lastRecord.CaseNo != null)
            {
                string numericPart = lastRecord.CaseNo.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"FP{newIdNumber:D4}"; // Formats as FP0001, FP0010, etc.
        }
        // Family Planning
        private string GenerateHearingID()
        {
            var lastRecord = unitOfWork.Repository<NewbornHearing>()
                .AsQueryable()
                .OrderByDescending(p => p.HearingNo)
                .FirstOrDefault();

            int newIdNumber = 1;

            if (lastRecord != null && lastRecord.HearingNo != null)
            {
                string numericPart = lastRecord.HearingNo.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"HR{newIdNumber:D4}"; // Formats as HR0001, HR0010, etc.
        }
        // Newborn Screening
        private string GenerateScreeningID()
        {
            var lastRecord = unitOfWork.Repository<NewbornScreening>()
                .AsQueryable()
                .OrderByDescending(p => p.ScreeningNo)
                .FirstOrDefault();

            int newIdNumber = 1;

            if (lastRecord != null && lastRecord.ScreeningNo != null)
            {
                string numericPart = lastRecord.ScreeningNo.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"SC{newIdNumber:D4}"; // Formats as HR0001, HR0010, etc.

        }

    }
}

