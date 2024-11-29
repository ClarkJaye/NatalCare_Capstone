using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class BillingController : BaseController<BillingController>
    {
        public BillingController(IModuleAccessServices moduleAccessServices)
            : base(moduleAccessServices)
        {
        }

        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(7)) // Invoice List
            {
                return RedirectToDashboard();
            }

            return View();
        }

        public async Task<IActionResult> InvoiceList()
        {
            if (!await CheckAccessAsync(7)) // Invoice List
            {
                return RedirectToDashboard();
            }

            return View();
        }

        public async Task<IActionResult> GenerateInvoice()
        {
            if (!await CheckAccessAsync(8)) // Gnerate Invoice
            {
                return RedirectToDashboard();
            }

            return View();
        }

    }
}
