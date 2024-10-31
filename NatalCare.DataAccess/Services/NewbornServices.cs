using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Services
{
    internal class NewbornServices : INewbornServices
    {
        private readonly IAppUnitOfWork unitOfWork;

        public NewbornServices(IAppUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse> GetNewborns()
        {
            var newborns = await unitOfWork.Repository<Newborn>()
                .GetAllAsync(includeProperties: "Patient");

            if (newborns == null || !newborns.Any())
                return new GeneralResponse(false, null, "There are no patients.");

            return new GeneralResponse(true, newborns, "Successfully Fetched.");
        }

        public async Task<GeneralResponse> GetInformation(string id)
        {
            var record = await unitOfWork.Repository<Newborn>()
                .GetFirstOrDefaultAsync(x => x.NewbornID == id, includeProperties: "Patient");

            if (record == null) return new GeneralResponse(false, null, "Newborn Not Found.");

            return new GeneralResponse(true, record, "Successfully Fetched.");
        }

        public async Task<CommonResponse> Create(Newborn newborn, string userId)
        {
            if (newborn == null)
                return new CommonResponse(false, "Newborn cannot be null.");

            // Validation checks
            if (await unitOfWork.Repository<Newborn>().AnyAsync(x => x.NewbornID == newborn.NewbornID))
                return new CommonResponse(false, "Newborn already exists!");

            // Generate a new PatientID
            newborn.NewbornID = await GenerateNewbornID();
            newborn.Created_At = DateTime.Now;
            newborn.StatusCode = "AC";
            newborn.NewbornCreatedBy = userId;

            unitOfWork.Repository<Newborn>().Add(newborn);
            await unitOfWork.SaveAsync();
            return new CommonResponse(true, "Newborn Successfully Created!"); 
        }

        public async Task<GeneralResponse> Edit(string id, string userId)
        {
            var record = await unitOfWork.Repository<Newborn>().GetFirstOrDefaultAsync(p => p.NewbornID == id, includeProperties: "Patient");

            if (record == null)
                return new GeneralResponse(false, null, "Newborn not found.");

            return new GeneralResponse(true, record, "Newborn Found Successful!");
        }

        // HELPER
        public async Task<(int todayCount, int monthCount, int yearCount)> GetNewbornCountsAsync()
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var yearStart = new DateTime(today.Year, 1, 1);

            var counts = await unitOfWork.Repository<Newborn>()
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
        private async Task<string> GenerateNewbornID()
        {
            var lastPatient = await unitOfWork.Repository<Newborn>()
                .AsQueryable()
                .OrderByDescending(p => p.NewbornID)
                .FirstOrDefaultAsync();

            int newIdNumber = 1; // Start at 1 if no patients are found

            if (lastPatient != null && lastPatient.NewbornID != null)
            {
                string numericPart = lastPatient.NewbornID.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }

            return $"NB{newIdNumber:D4}";
        }

      
    }
}
