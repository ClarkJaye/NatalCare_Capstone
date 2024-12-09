using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ReportsController : BaseController<ReportsController>
    {
        public ReportsController(IModuleAccessServices moduleAccessServices)
         : base(moduleAccessServices)
        {
        }
        public async Task<IActionResult> Natality()
        {
            if (!await CheckAccessAsync(9)) // Natality Reports
            {
                return RedirectTo();
            }
            return View();
        }

        public async Task<IActionResult> Invoices()
        {
            if (!await CheckAccessAsync(10)) // Payment Reports
            {
                return RedirectTo();
            }
            return View();
        }

    }
}
