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
                return new GeneralResponse(false, null, "Prenatal record not existing.");

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
            if(caseNo == null)
                return new CommonResponse(false, "CaseNo cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            var item = await unitOfWork.Repository<Prenatal>().GetFirstOrDefaultAsync(x => x.CaseNo == caseNo);
            if (item == null)
                return new CommonResponse(false, "Prenatal record not found.");

            item.StatusCode = "DL";
            item.Updated_At = DateTime.Now;
            item.PrenatalUpdatedBy = userId;

            unitOfWork.Repository<Prenatal>().Update(item);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal record deleted successfully");
        }


        // Prenatal Visit
        public async Task<CommonResponse> AddPrenatalVisitRecordAsync(PrenatalVisit prenatalvisit, string patientId, string caseNo, string userId)
        {
            if (prenatalvisit == null)
                return new CommonResponse(false, "Prenatal cannot be null!");

            // Validation checks: Ensure CaseNo is unique if needed.
            if (await unitOfWork.Repository<PrenatalVisit>().AnyAsync(x => x.PrenatalVisitID == prenatalvisit.PrenatalVisitID))
                return new CommonResponse(false, "Prenatal record already exists.");

            // Generate a new CaseNo for the record.
            prenatalvisit.CaseNo = caseNo;
            prenatalvisit.PatientID = patientId;
            prenatalvisit.Created_At = DateTime.Now;
            prenatalvisit.StatusCode = "AC";
            prenatalvisit.PrenatalCreatedBy = userId;

            unitOfWork.Repository<PrenatalVisit>().Add(prenatalvisit);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Prenatal record added successfully");
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
            existingRecord.NumberOfVisit = prenatal.NumberOfVisit;
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
    }
}
