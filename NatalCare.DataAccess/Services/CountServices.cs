using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Services
{
    internal class CountServices : ICountServices
    {
        private readonly IAppUnitOfWork unitOfWork;

        public CountServices(IAppUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<(int totalAdmitted, int totalInLabor, int totalPospartum)> GetAdmissionCountsAsync()
        {

            var counts = await unitOfWork.Repository<Delivery>()
                .AsQueryable()
                .GroupBy(n => 1)
                .Select(g => new
                {
                    TotalAdmitted = g.Count(n => n.DeliveryStatusID == 1 || n.DeliveryStatusID == 2),

                    TotalInLabor = g.Count(n => n.DeliveryStatusID == 1),

                    TotalPospartum = g.Count(n => n.DeliveryStatusID == 2),
                })
                .FirstOrDefaultAsync();

            // If counts are found, return the count values, else return zeros
            return counts != null ? (counts.TotalAdmitted, counts.TotalInLabor, counts.TotalPospartum) : (0, 0, 0);
        }

        //public async Task<(int totalCount, int todayCount)> GetOPDCountsAsync()
        //{
        //    var today = DateTime.Today;

        //    var counts = await unitOfWork.Repository<OpdVisit>()
        //        .AsQueryable()
        //        .GroupBy(n => 1)
        //        .Select(g => new
        //        {
        //            TodayCount = g.Count(n => n.Created_At >= today),
        //            TotalCount = g.Count(),
        //        })
        //        .FirstOrDefaultAsync();

        //    return counts != null ? (counts.TotalCount, counts.TodayCount) : (0, 0);
        //}



        public async Task<(int todayCount, int monthCount, int yearCount, int TotalCount)> GetOPDCountsAsync()
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var yearStart = new DateTime(today.Year, 1, 1);

            var counts = await unitOfWork.Repository<OpdVisit>()
                .AsQueryable()
                .GroupBy(n => 1)
                .Select(g => new
                {
                    // Count created today
                    TodayCount = g.Count(n => n.Created_At >= today),
                    // Count created this month
                    MonthCount = g.Count(n => n.Created_At >= monthStart),
                    // Count created this year
                    YearCount = g.Count(n => n.Created_At >= yearStart),
                    // Count Total
                    TotalCount = g.Count(),
                })
                .FirstOrDefaultAsync();

            // If counts are found, return the count values, else return zeros
            return counts != null ? (counts.TodayCount, counts.MonthCount, counts.YearCount, counts.TotalCount) : (0, 0, 0, 0);
        }

    }
}
