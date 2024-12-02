using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
