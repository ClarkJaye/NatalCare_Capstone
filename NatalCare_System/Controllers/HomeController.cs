using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models;
using NatalCare.Utility;
using System.Diagnostics;
using System.Security.Claims;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class HomeController : BaseController<HomeController>
    {
        private readonly IPatientServices patientServices;
        public HomeController(IPatientServices patientServices, IModuleAccessServices moduleAccessServices)
            : base(moduleAccessServices)
        {
            this.patientServices = patientServices;
        }
        public async Task<IActionResult> Dashboard()
        {
            var result = await patientServices.GetRecentPatientsAsync();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetDataByYearAndMonth(int year, int month)
        {
            var result = await patientServices.PatientStatistics(year, month);

            return Json(result?.Item ?? new List<object>());
        }

        [HttpGet]
        public async Task<IActionResult> GetBarDataByYearAndMonth(int year, int month)
        {
            var result = await patientServices.ServicesStatistics(year, month);
            return Json(result?.Item ?? new List<object>());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
