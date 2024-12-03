using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class OPDController : BaseController<AdmissionController>
    {
        private readonly IServicesOperationServices serviceServices;
        private readonly ICountServices countservices;

        public OPDController(ICountServices countservices, IServicesOperationServices serviceServices, IModuleAccessServices moduleAccessServices)
         : base(moduleAccessServices)
        {
            this.serviceServices = serviceServices;
            this.countservices = countservices;

        }

        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(5))
            {
                return RedirectTo();
            }

            var (todayRecordCount, monthlyRecordCount, yearlyRecordCount, totalCount) = await countservices.GetOPDCountsAsync();
            // Pass counts to the view using ViewBag
            ViewBag.TodayRecord = todayRecordCount;
            ViewBag.MonthlyRecord = monthlyRecordCount;
            ViewBag.YearlyRecord = yearlyRecordCount;
            ViewBag.TotalRecord = totalCount;

            var records = await serviceServices.GetAllOPDRecords();
            return View(records ?? new List<OpdVisit>());
        }

    }
}
