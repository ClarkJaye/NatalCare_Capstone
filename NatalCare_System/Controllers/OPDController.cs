using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class OPDController : BaseController<AdmissionController>
    {
        public OPDController(IModuleAccessServices moduleAccessServices)
         : base(moduleAccessServices)
        {
        }

        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(5))
            {
                return RedirectToDashboard();
            }
            return View();
        }


        public IActionResult Information()
        {
            return View();
        }


    }
}
