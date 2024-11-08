using Microsoft.AspNetCore.Mvc;

namespace NatalCare_System.Controllers
{
    public class BillingController : BaseController<BillingController>
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InvoiceList()
        {
            return View();
        }

        public IActionResult GenerateInvoice()
        {
            return View();
        }
        
    }
}
