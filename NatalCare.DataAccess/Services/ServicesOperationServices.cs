using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
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
            prenatal.CaseNo = await GeneratePrenatalID();
            prenatal.PatientID = patientId;
            prenatal.Created_At = DateTime.Now;
            prenatal.StatusCode = "AC";
            prenatal.PrenatalCreatedBy = userId;
            prenatal.PrenatalVisitTotal = 0;

            if (prenatal.PrenatalVisitTotal == 0)
            {
                OpdVisit opd = new OpdVisit();
                opd.ReasonForVisit = "Prenatal Check up";
                opd.ServiceID = prenatal.CaseNo;
                opd.DateVisit = prenatal.DateVisit;
                opd.PatientID = prenatal.PatientID;
                opd.Created_At = prenatal.Created_At;
                opd.OPDCreatedBy = userId;
                opd.StatusCode = "AC";
                unitOfWork.Repository<OpdVisit>().Add(opd);
            }

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
        public async Task<Prenatal> GetPrenatalInformation(string id)
        {
            var prenatal = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(p => p.CaseNo == id);

            if (prenatal == null)
                return new Prenatal();

            return prenatal;
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

            var prenatalalMain = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(x => x.CaseNo == prenatalvisit.CaseNo);
            if(prenatalalMain != null)
            {
                prenatalalMain.PrenatalVisitTotal += 1 ;
                OpdVisit opd = new OpdVisit();
                opd.ReasonForVisit = "Prenatal Check up";
                opd.ServiceID = prenatalalMain.CaseNo;
                opd.DateVisit = prenatalalMain.DateVisit;
                opd.PatientID = prenatalalMain.PatientID;
                opd.Created_At = prenatalalMain.Created_At;
                opd.OPDCreatedBy = userId;
                opd.StatusCode = "AC";
                unitOfWork.Repository<OpdVisit>().Add(opd);
            }
            
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
            fp.CaseNo = await GenerateFPID();
            fp.PatientID = patientId;
            fp.Created_At = DateTime.Now;
            fp.StatusCode = "AC";
            fp.FPCreatedBy = userId;

            if (fp.CaseNo != null)
            {
                OpdVisit opd = new OpdVisit();
                opd.ReasonForVisit = "Newborn Screening";
                opd.DateVisit = fp.DateVisit;
                opd.PatientID = fp.PatientID;
                opd.Created_At = fp.Created_At;
                opd.OPDCreatedBy = userId;
                opd.StatusCode = "AC";
                unitOfWork.Repository<OpdVisit>().Add(opd);
            }

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
            item.HearingNo = await GenerateHearingID();
            item.PatientID = patientId;
            item.Created_At = DateTime.Now;
            item.StatusCode = "AC";
            item.HearingCreatedBy = userId;

            if (item.HearingNo != null)
            {
                OpdVisit opd = new OpdVisit();
                opd.ReasonForVisit = "Newborn Hearing";
                opd.ServiceID = item.HearingNo;
                opd.DateVisit = item.DateVisit;
                opd.PatientID = item.PatientID;
                opd.Created_At = item.Created_At;
                opd.OPDCreatedBy = userId;
                opd.StatusCode = "AC";
                unitOfWork.Repository<OpdVisit>().Add(opd);
            }

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
            var item = await unitOfWork.Repository<NewbornHearing>().GetFirstOrDefaultAsync(x => x.HearingNo == caseNo, includeProperties: "Newborn");
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
                practitioner = item.AttendingPractitioner,
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
            existingRecord.AttendingPractitioner = item.AttendingPractitioner;
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
            item.ScreeningNo = await GenerateScreeningID();
            item.PatientID = patientId;
            item.Created_At = DateTime.Now;
            item.StatusCode = "AC";
            item.ScreeningCreatedBy = userId;
            unitOfWork.Repository<NewbornScreening>().Add(item);

            if(item.ScreeningNo != null)
            {
                OpdVisit opd = new OpdVisit();
                opd.ReasonForVisit = "Newborn Screening";
                opd.ServiceID = item.ScreeningNo;
                opd.DateVisit = item.DateVisit;
                opd.PatientID = item.PatientID;
                opd.Created_At = item.Created_At;
                opd.OPDCreatedBy = userId;
                opd.StatusCode = "AC";
                unitOfWork.Repository<OpdVisit>().Add(opd);
            }

            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Newborn Screening record added successfully");
        }
        public async Task<GeneralResponse> GetScreeningRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Case No cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<NewbornScreening>().GetFirstOrDefaultAsync(x => x.ScreeningNo == caseNo, includeProperties: "Newborn");
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
                screeningResults = item.ScreeningResults,
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

        // Delivery
        public async Task<List<Delivery>> GetDeletedDeliveryRecords(string patientId)
        {
            var record = await unitOfWork.Repository<Delivery>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "DL", includeProperties: "Newborn,DeliveryStatus");
            if (!record.Any())
            {
                return new List<Delivery>();
            }
            return record.ToList();
        }
        public async Task<Delivery> GetDeliveryRecord(string patientId, string caseno)
        {
            var record = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == caseno);
            if (record == null)
            {
                return new Delivery();
            }
            return record;
        }
        public async Task<List<Delivery>> GetDeliveryRecords(string patientId)
        {
            var record = await unitOfWork.Repository<Delivery>().GetAllAsync(p => p.PatientID == patientId && p.StatusCode == "AC", includeProperties: "Newborn,DeliveryStatus,CreatedBy,Wards,Beds");
            if (!record.Any())
            {
                return new List<Delivery>();
            }
            return record.ToList();
        }
        public async Task<CommonResponse> AddDeliveryRecordAsync(Delivery delivery, string patientId, string userId)
        {
            if (delivery == null)
                return new CommonResponse(false, "Delivery cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<Delivery>().AnyAsync(x => x.CaseNo == delivery.CaseNo))
                return new CommonResponse(false, "Delivery record already exists.");

            // Generate a new CaseNo for the record.
            delivery.CaseNo = await GenerateDeliveryID();
            delivery.PatientID = patientId;
            delivery.Created_At = DateTime.Now;
            delivery.StatusCode = "AC";
            delivery.DLCreatedBy = userId;

            unitOfWork.Repository<Delivery>().Add(delivery);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Delivery record added successfully");
        }
        public async Task<GeneralResponse> GetDeliveryRecordAsync(string caseNo)
        {
            if (caseNo == null)
                return new GeneralResponse(false, null, "Case No cannot found!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new GeneralResponse(false, item, "Delivery record not existing.");

            var prenatal = await unitOfWork.Repository<Prenatal>()
                                          .AsQueryable()
                                          .Where(a => a.PatientID == item.PatientID)
                                          .Select(a => new
                                          {
                                              caseNo = a.CaseNo,
                                          })
                                          .ToListAsync();

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

            var deliveryStatus = await unitOfWork.Repository<DeliveryStatus>()
                                           .AsQueryable()
                                           .Select(a => new
                                           {
                                               id = a.Id,
                                               statusName = a.StatusName,
                                           })
                                           .ToListAsync();
            var data = new
            {
                caseNo = item.CaseNo,
                patientId = item.PatientID,
                date_admitted = item.Date_Admitted,
                time_admitted = item.Time_Admitted,
                date_discharged = item.Date_Discharged,
                wardNo = item.WardNumber,
                prenatalId = item.PrenatalID,
                newbornId = item.NewbornID,
                statusId = item.DeliveryStatusID,
                notes = item.Notes,
            };

            return new GeneralResponse(true, new { data, prenatal, newborn, deliveryStatus }, "Delivery record fetched successfully!.");
        }
        public async Task<CommonResponse> UpdateDeliveryRecordAsync(Delivery delivery, string userId)
        {
            var existingRecord = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(p => p.CaseNo == delivery.CaseNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Delivery record not found.");

            // Update the existing record fields
            existingRecord.Date_Admitted = delivery.Date_Admitted;
            existingRecord.Time_Admitted = delivery.Time_Admitted;
            existingRecord.Date_Discharged = delivery.Date_Discharged;
            existingRecord.WardNumber = delivery.WardNumber;
            existingRecord.PrenatalID = delivery.PrenatalID;
            existingRecord.NewbornID = delivery.NewbornID;
            existingRecord.DeliveryStatusID = delivery.DeliveryStatusID;
            existingRecord.Notes = delivery.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.DLUpdatedBy = userId;

            unitOfWork.Repository<Delivery>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Delivery record updated successfully.");
        }
        public async Task<CommonResponse> DeleteDeliveryRecordAsync(string caseNo, string userId)
        {
            if (caseNo == null)
                return new CommonResponse(false, "CaseNo cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Delivery record not found.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.DLUpdatedBy = userId;

            unitOfWork.Repository<Delivery>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Delivery record deleted successfully");
        }
        public async Task<CommonResponse> RetrievedDeliveryAync(string caseno, string userId)
        {
            var record = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(p => p.CaseNo == caseno);
            if (record == null)
            {
                return new CommonResponse(false, "Record Not Found.");
            }
            record.StatusCode = "AC";
            record.DLUpdatedBy = userId;
            record.Updated_At = DateTime.Now;

            unitOfWork.Repository<Delivery>().Update(record);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record Retrieved Successfully.");
        }



        //ADMISSION PART
        public async Task<List<Delivery>> GetAllDeliveryRecords()
        {
            var record = await unitOfWork.Repository<Delivery>().GetAllAsync(p => p.StatusCode == "AC", includeProperties: "Patient,Newborn,DeliveryStatus,Wards,Beds");
            return record.ToList();
        }
        public async Task<Delivery> GetAdmittedDeliveryRecord(string caseno)
        {
            var record = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(p => p.CaseNo == caseno);
            if (record == null)
            {
                return new Delivery();
            }
            return record;
        }

        public async Task<CommonResponse> AddAdmissionDelivery(Delivery data, string userId)
        {
            if (data == null)
                return new CommonResponse(false, "Delivery cannot be null.");

            // Validation checks
            if (await unitOfWork.Repository<Delivery>().AnyAsync(x => x.CaseNo == data.CaseNo))
                return new CommonResponse(false, "Delivery already exists!");

            // Generate a new PatientID
            data.CaseNo = await GenerateDeliveryID();
            data.Created_At = DateTime.Now;
            data.StatusCode = "AC";
            data.DLCreatedBy = userId;

            var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(x => x.PatientID == data.PatientID);

            if(patient != null)
            {
                patient.StatusCode = "AD";
                unitOfWork.Repository<Patients>().Update(patient);
            }


            if (data.BedNumber != null)
            {
                var bed = await unitOfWork.Repository<Bed>().GetFirstOrDefaultAsync(x=> x.Id == data.BedNumber);
                if(bed != null)
                {
                    bed.IsUsed = true;
                    bed.PatientID = data.PatientID;
                    unitOfWork.Repository<Bed>().Update(bed);
                }
            }

            unitOfWork.Repository<Delivery>().Add(data);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Delivery Successfully Created!");
        }

        public async Task<CommonResponse> UpdateAdmissionDelivery(Delivery item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<Delivery>().GetFirstOrDefaultAsync(p => p.CaseNo == item.CaseNo);

            if (existingRecord == null)
                return new CommonResponse(false, "Record not found.");

            if (existingRecord.BedNumber != item.BedNumber)
            {
                var prevbed = await unitOfWork.Repository<Bed>().GetFirstOrDefaultAsync(x => x.Id == existingRecord.BedNumber);
                if (prevbed != null)
                {
                    prevbed.IsUsed = false;
                    prevbed.PatientID = null;
                    unitOfWork.Repository<Bed>().Update(prevbed);
                    await unitOfWork.SaveAsync();
                }

                var bed = await unitOfWork.Repository<Bed>().GetFirstOrDefaultAsync(x => x.Id == item.BedNumber);
                if (bed != null)
                {
                    bed.IsUsed = true;
                    bed.PatientID = item.PatientID;
                    unitOfWork.Repository<Bed>().Update(bed);
                    await unitOfWork.SaveAsync();
                }
            }
            // Update the existing record fields
            existingRecord.Date_Admitted = item.Date_Admitted;
            existingRecord.Time_Admitted = item.Time_Admitted;
            existingRecord.Date_Discharged = item.Date_Discharged;
            existingRecord.Time_Discharged = item.Time_Discharged;
            existingRecord.WardNumber = item.WardNumber;
            existingRecord.BedNumber = item.BedNumber;
            existingRecord.DeliveryStatusID = item.DeliveryStatusID;
            existingRecord.PrenatalID = item.PrenatalID;
            existingRecord.NewbornID = item.NewbornID;
            existingRecord.PatientID = item.PatientID;
            existingRecord.Notes = item.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.DLUpdatedBy = userId;

            if(item.DeliveryStatusID == 3)
            {
                var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(x => x.PatientID == item.PatientID);
                if(patient != null)
                {
                    patient.StatusCode = "AC";
                    unitOfWork.Repository<Patients>().Update(patient);
                }
            }
            else if (item.DeliveryStatusID != 3)
            {
                var patient = await unitOfWork.Repository<Patients>().GetFirstOrDefaultAsync(x => x.PatientID == item.PatientID);
                if (patient != null)
                {
                    patient.StatusCode = "AD";
                    unitOfWork.Repository<Patients>().Update(patient);
                }
            }
            unitOfWork.Repository<Delivery>().Update(existingRecord);

            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Record updated successfully.");
        }



        //OPD PART
        public async Task<List<OpdVisit>> GetAllOPDRecords()
        {
            var record = await unitOfWork.Repository<OpdVisit>().GetAllAsync(p => p.StatusCode == "AC", includeProperties: "Patient");
            return record.ToList();
        }
        public async Task<OpdVisit> GetOPDRecord(int id)
        {
            var item = await unitOfWork.Repository<OpdVisit>().GetFirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return new OpdVisit();
            return item;
        }
        public async Task<GeneralResponse> GetOPDDataRecord(int id)
        {
            var item = await unitOfWork.Repository<OpdVisit>().GetFirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return new GeneralResponse(false, null, "OPD record not found.");

            object data = null; // Initialize a variable to store additional data

            // Check the reason for the visit and retrieve relevant data
            switch (item.ReasonForVisit?.ToLower())
            {
                case "newborn hearing":
                    data = await unitOfWork.Repository<NewbornHearing>().GetFirstOrDefaultAsync(x => x.HearingNo == item.ServiceID);
                    break;

                case "newborn screening":
                    data = await unitOfWork.Repository<NewbornScreening>().GetFirstOrDefaultAsync(x => x.ScreeningNo == item.ServiceID);
                    break;

                case "prenatal check up":
                    data = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(x => x.CaseNo == item.ServiceID);
                    break;

                default:
                    return new GeneralResponse(false, data, "No specific service data found.");
            }

            return new GeneralResponse(true, data , "service data retrieved successfully.");
        }





        //Physical Examination Records
        public async Task<PhysicalExamination> GetPhysicalExaminationRecords(string patientId, string deliveryId)
        {
            var record = await unitOfWork.Repository<PhysicalExamination>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == deliveryId && p.StatusCode == "AC", includeProperties: "Patient");
            if (record == null)
            {
                return new PhysicalExamination();
            }
            return record;
        }
        public async Task<GeneralResponse> GetPhysicalExaminationRecord(int id)
        {
            var data = await unitOfWork.Repository<PhysicalExamination>().GetFirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new GeneralResponse(false, data, "Physical examination record not existing.");

            return new GeneralResponse(true, data, "Physical examination record retreived successfully!.");
        }
        public async Task<CommonResponse> AddPERecordAsync(PhysicalExamination item, string patientId, string userId,string deliveryId)
        {
            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<PhysicalExamination>().AnyAsync(x => x.CaseNo == item.CaseNo))
                return new CommonResponse(false, "Physical examination record already exists.");

            item.PatientID = patientId;
            item.CaseNo = deliveryId;
            item.Created_At = DateTime.Now;
            item.PECreatedBy = userId;
            item.StatusCode = "AC";

            unitOfWork.Repository<PhysicalExamination>().Add(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Physical examination added successfully");
        }
        public async Task<CommonResponse> UpdatePERecordAsync(PhysicalExamination item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<PhysicalExamination>().GetFirstOrDefaultAsync(p => p.Id == item.Id);

            if (existingRecord == null)
                return new CommonResponse(false, "Physical examination record not found.");

            // Update the existing record fields
            existingRecord.Weight = item.Weight;
            existingRecord.Height = item.Height;
            existingRecord.BP = item.BP;
            existingRecord.PulseRate = item.PulseRate;
            existingRecord.RespiratoryRate = item.RespiratoryRate;
            existingRecord.Temperature = item.Temperature;
            existingRecord.Skin_Normal = item.Skin_Normal;
            existingRecord.Skin_Pale = item.Skin_Pale;
            existingRecord.Skin_Yellowish = item.Skin_Yellowish;
            existingRecord.Skin_Hematoma = item.Skin_Hematoma;
            existingRecord.Breast_Normal = item.Breast_Normal;
            existingRecord.Breast_Mass = item.Breast_Mass;
            existingRecord.Breast_NippleDischarged = item.Breast_NippleDischarged;
            existingRecord.Conjunctive_Normal = item.Conjunctive_Normal;
            existingRecord.Conjunctive_Pale = item.Conjunctive_Pale;
            existingRecord.Conjunctive_YW = item.Conjunctive_YW;
            existingRecord.Abdomen_Normal = item.Abdomen_Normal;
            existingRecord.Abdomen_Mass = item.Abdomen_Mass;
            existingRecord.Abdomen_Varicosities = item.Abdomen_Varicosities;
            existingRecord.Neck_Normal = item.Neck_Normal;
            existingRecord.Neck_Mass = item.Neck_Mass;
            existingRecord.Neck_EnlargedLymphNodes = item.Neck_EnlargedLymphNodes;
            existingRecord.Extremities_Normal = item.Extremities_Normal;
            existingRecord.Extremities_Edema = item.Extremities_Edema;
            existingRecord.Extremities_Varicosities = item.Extremities_Varicosities;
            existingRecord.OBHistory = item.OBHistory;
            existingRecord.Notes = item.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.PEUpdatedBy = userId;

            unitOfWork.Repository<PhysicalExamination>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Physical examination record updated successfully.");
        }



        //Maternal Monitoring Records
        public async Task<MaternalMonitoring> GetMaternalMonitoringRecords(string patientId, string deliveryId)
        {
            var record = await unitOfWork.Repository<MaternalMonitoring>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == deliveryId && p.StatusCode == "AC");
            if (record == null)
            {
                return new MaternalMonitoring();
            }
            return record;
        }



        //Obstetrical Records
        public async Task<Obstetrical> GetObstetricalRecords(string patientId, string deliveryId)
        {
            var record = await unitOfWork.Repository<Obstetrical>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == deliveryId && p.StatusCode == "AC", includeProperties: "Patient,Patient.Spouse");
            if (record == null)
            {
                return new Obstetrical();
            }
            return record;
        }
        public async Task<CommonResponse> AddOBRecordAsync(Obstetrical item, string patientId, string userId, string deliveryId)
        {
            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<Obstetrical>().AnyAsync(x => x.CaseNo == item.CaseNo))
                return new CommonResponse(false, "OBstetrical record already exists.");

            item.PatientID = patientId;
            item.CaseNo = deliveryId;
            item.Created_At = DateTime.Now;
            item.ObsCreatedBy = userId;
            item.StatusCode = "AC";

            unitOfWork.Repository<Obstetrical>().Add(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "OBstetrical added successfully");
        }
        public async Task<GeneralResponse> GetOBRecord(int id)
        {
            var data = await unitOfWork.Repository<Obstetrical>().GetFirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new GeneralResponse(false, data, "Obstetrical record not existing.");

            return new GeneralResponse(true, data, "Obstetrical record retreived successfully!.");
        }
        public async Task<CommonResponse> UpdateOBRecordAsync(Obstetrical item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<Obstetrical>().GetFirstOrDefaultAsync(p => p.ID == item.ID);

            if (existingRecord == null)
                return new CommonResponse(false, "Obstetrical record not found.");

            // Update the existing record fields
            existingRecord.FirstDayOfLastMenstrualCycle = item.FirstDayOfLastMenstrualCycle;
            existingRecord.PriorMensesDate = item.PriorMensesDate;
            existingRecord.FrequencyOfCycleEvery = item.FrequencyOfCycleEvery;
            existingRecord.DaysMensesMonthly = item.DaysMensesMonthly;
            existingRecord.AgesOfFirstMenses = item.AgesOfFirstMenses;
            existingRecord.BirthControlTheOfPregnancy = item.BirthControlTheOfPregnancy;
            existingRecord.DateOfPositivePregnancyTest = item.DateOfPositivePregnancyTest;
            existingRecord.PregnancyTestDoneBy = item.PregnancyTestDoneBy;
            existingRecord.TotalNoOfPreg = item.TotalNoOfPreg;
            existingRecord.NoOf_FullTerm = item.NoOf_FullTerm;
            existingRecord.NoOf_Premature = item.NoOf_Premature;
            existingRecord.NoOfAbortions = item.NoOfAbortions;
            existingRecord.NoOfMiscarriages = item.NoOfMiscarriages;
            existingRecord.NoOfD_CWithCarriagesPregnancy = item.NoOfD_CWithCarriagesPregnancy;
            existingRecord.NoOfPregnancy_TubalPregnancy = item.NoOfPregnancy_TubalPregnancy;
            existingRecord.NoOfMultipleBirths = item.NoOfMultipleBirths;
            existingRecord.NoOfLiving = item.NoOfLiving;
            existingRecord.PregnancyMonthYear = item.PregnancyMonthYear;
            existingRecord.NoOfWeeks = item.NoOfWeeks;
            existingRecord.LaborLengthHours = item.LaborLengthHours;
            existingRecord.BirthWeigth = item.BirthWeigth;
            existingRecord.BirthSex = item.BirthSex;
            existingRecord.Vaginal_CS = item.Vaginal_CS;
            existingRecord.AnesthesiaType = item.AnesthesiaType;
            existingRecord.PlaceOfDelivery = item.PlaceOfDelivery;
            existingRecord.PretermLabor = item.PretermLabor;
            existingRecord.ComplicationsOrComments = item.ComplicationsOrComments;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.ObsUpdatedBy = userId;

            unitOfWork.Repository<Obstetrical>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Obstetrical record updated successfully.");
        }



        //Clinical Sheets Records
        public async Task<ClinicalFaceSheet> GetClinicalSheetRecords(string patientId, string deliveryId)
        {
            var record = await unitOfWork.Repository<ClinicalFaceSheet>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == deliveryId && p.StatusCode == "AC");
            if (record == null)
            {
                return new ClinicalFaceSheet();
            }
            return record;
        }
        public async Task<CommonResponse> AddCFRecordAsync(ClinicalFaceSheet item, string patientId, string userId, string deliveryId)
        {
            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<ClinicalFaceSheet>().AnyAsync(x => x.CaseNo == item.CaseNo))
                return new CommonResponse(false, "Clinical face sheet record already exists.");

            item.PatientID = patientId;
            item.CaseNo = deliveryId;
            item.Created_At = DateTime.Now;
            item.ClinicalCreatedBy = userId;
            item.StatusCode = "AC";

            unitOfWork.Repository<ClinicalFaceSheet>().Add(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Clinical face sheet added successfully");
        }
        public async Task<GeneralResponse> GetCFRecord(int id)
        {
            var data = await unitOfWork.Repository<ClinicalFaceSheet>().GetFirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new GeneralResponse(false, data, "Clinical face sheet record not existing.");

            return new GeneralResponse(true, data, "Clinical face sheet record retreived successfully!.");
        }
        public async Task<CommonResponse> UpdateCFRecordAsync(ClinicalFaceSheet item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<ClinicalFaceSheet>().GetFirstOrDefaultAsync(p => p.ID == item.ID);

            if (existingRecord == null)
                return new CommonResponse(false, "Clinical face sheet record not found.");
            

            unitOfWork.Repository<ClinicalFaceSheet>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Clinical face sheet record updated successfully.");
        }


        //Dischagement Form Records
        public async Task<DischargementForm> GetDischargementRecords(string patientId, string deliveryId)
        {
            var record = await unitOfWork.Repository<DischargementForm>().GetFirstOrDefaultAsync(p => p.PatientID == patientId && p.CaseNo == deliveryId && p.StatusCode == "AC", includeProperties: "Patient,Delivery,Midwife,Prepared");
            if (record == null)
            {
                return new DischargementForm();
            }
            return record;
        }
        public async Task<CommonResponse> AddDFRecordAsync(DischargementForm item, string patientId, string userId, string deliveryId)
        {
            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<DischargementForm>().AnyAsync(x => x.CaseNo == item.CaseNo))
                return new CommonResponse(false, "Dischargement record already exists.");

            item.PatientID = patientId;
            item.CaseNo = deliveryId;
            item.Created_At = DateTime.Now;
            item.DeliveryCreatedBy = userId;
            item.StatusCode = "AC";

            unitOfWork.Repository<DischargementForm>().Add(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Dischargement added successfully");
        }
        public async Task<GeneralResponse> GetDFRecord(int id)
        {
            var data = await unitOfWork.Repository<DischargementForm>().GetFirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new GeneralResponse(false, data, "Dischargement record not existing.");

            var prepared = await unitOfWork.Repository<Staff>()
                                          .AsQueryable()
                                          .Select(a => new
                                          {
                                              id = a.Id,
                                              firstname = a.FirstName,
                                              middlename = a.MiddleName,
                                              lastname = a.LastName,
                                          })
                                          .ToListAsync();

            var midwife = await unitOfWork.Repository<Staff>()
                                          .AsQueryable()
                                          .Where(a => a.RoleId == 2)
                                          .Select(a => new
                                          {
                                              id = a.Id,
                                              firstname = a.FirstName,
                                              middlename = a.MiddleName,
                                              lastname = a.LastName,
                                          })
                                          .ToListAsync();

            return new GeneralResponse(true, new { data, prepared, midwife }, "Dischargement record retreived successfully!.");
        }
        public async Task<CommonResponse> UpdateDFRecordAsync(DischargementForm item, string userId)
        {
            var existingRecord = await unitOfWork.Repository<DischargementForm>().GetFirstOrDefaultAsync(p => p.Id == item.Id);

            if (existingRecord == null)
                return new CommonResponse(false, "Dischargement record not found.");

            // Update the existing record fields
            existingRecord.Hosp_No = item.Hosp_No;
            existingRecord.CompleteDiagnosis = item.CompleteDiagnosis;
            existingRecord.Medications = item.Medications;
            existingRecord.PostpartumCareAndHygiene = item.PostpartumCareAndHygiene;
            existingRecord.Nutrition = item.Nutrition;
            existingRecord.IronFolate = item.IronFolate;
            existingRecord.BirthSpacingFamilyPlanning = item.BirthSpacingFamilyPlanning;
            existingRecord.DangerSignsMother = item.DangerSignsMother;
            existingRecord.FollowUpVisitsMother = item.FollowUpVisitsMother;
            existingRecord.ExclusiveBreastFeeding = item.ExclusiveBreastFeeding;
            existingRecord.HygieneCordCareWarmth = item.HygieneCordCareWarmth;
            existingRecord.SpecialAdviceLowBirthWeight = item.SpecialAdviceLowBirthWeight;
            existingRecord.DangerSignsBaby = item.FollowUpVisitsBaby;
            existingRecord.FollowUpManagement = item.FollowUpManagement;
            existingRecord.MidwifeID = item.MidwifeID;
            existingRecord.PreparedBy = item.PreparedBy;
            existingRecord.Notes = item.Notes;
            existingRecord.Updated_At = DateTime.UtcNow;
            existingRecord.DeliveryUpdatedBy = userId;

            unitOfWork.Repository<DischargementForm>().Update(existingRecord);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Dischargement record updated successfully.");
        }
























        //Generation of ID's
        // Delivery
        private async Task<string> GenerateDeliveryID()
        {
            var lastItem = await unitOfWork.Repository<Delivery>()
                .AsQueryable()
                .OrderByDescending(p => p.CaseNo)
                .FirstOrDefaultAsync();

            int newIdNumber = 1;

            if (lastItem != null && lastItem.CaseNo != null)
            {
                string numericPart = lastItem.CaseNo.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"AD{newIdNumber:D4}"; // Formats as AD0001, ADE0010, etc.
        }
        // Prenatal
        private async Task<string> GeneratePrenatalID()
        {
            var lastPrenatal = await unitOfWork.Repository<Prenatal>()
                .AsQueryable()
                .OrderByDescending(p => p.CaseNo)
                .FirstOrDefaultAsync();

            int newIdNumber = 1;

            if (lastPrenatal != null && lastPrenatal.CaseNo != null)
            {
                string numericPart = lastPrenatal.CaseNo.Substring(3);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"PRE{newIdNumber:D4}"; // Formats as PRE0001, PRE0010, etc.
        }
        // Family Planning
        private async Task<string> GenerateFPID()
        {
            var lastRecord = await unitOfWork.Repository<FamilyPlanning>()
                .AsQueryable()
                .OrderByDescending(p => p.CaseNo)
                .FirstOrDefaultAsync();

            int newIdNumber = 1;

            if (lastRecord != null && lastRecord.CaseNo != null)
            {
                string numericPart = lastRecord.CaseNo.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"FP{newIdNumber:D4}"; // Formats as FP0001, FP0010, etc.
        }
        // Family Planning
        private async Task<string> GenerateHearingID()
        {
            var lastRecord = await unitOfWork.Repository<NewbornHearing>()
                .AsQueryable()
                .OrderByDescending(p => p.HearingNo)
                .FirstOrDefaultAsync();

            int newIdNumber = 1;

            if (lastRecord != null && lastRecord.HearingNo != null)
            {
                string numericPart = lastRecord.HearingNo.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }
            return $"HR{newIdNumber:D4}"; // Formats as HR0001, HR0010, etc.
        }
        // Newborn Screening
        private async Task<string> GenerateScreeningID()
        {
            var lastRecord = await unitOfWork.Repository<NewbornScreening>()
                .AsQueryable()
                .OrderByDescending(p => p.ScreeningNo)
                .FirstOrDefaultAsync();

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

