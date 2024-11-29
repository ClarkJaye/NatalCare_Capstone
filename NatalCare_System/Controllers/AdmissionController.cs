using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class AdmissionController : BaseController<AdmissionController>
    {
        public AdmissionController(IModuleAccessServices moduleAccessServices)
           : base(moduleAccessServices)
        {
        }
        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(4)) 
            {
                RedirectToDashboard();
            }
            return View();
        }

        public async Task<IActionResult> Information()
        {
            if (!await CheckAccessAsync(4))
            {
                RedirectToDashboard();
            }
            return View();
        }


    }
}
