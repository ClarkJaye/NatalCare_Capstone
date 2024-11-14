using Microsoft.AspNetCore.Mvc;

using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.Controllers
{
    public class BillingController : BaseController<BillingController>
    {

        private readonly IBillingServices _billing;

        public BillingController(IBillingServices billing) { 
            _billing = billing;
        }

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

        [HttpPost]
        public async Task<IActionResult> AddItem(string itemName, string description, decimal price)
        {

            var (result, message) = await _billing.createItems(itemName, description, price);

            if (result)
            {
                return Json(message);
            }else
            {
                return Json("Cant Add Item");
            }

       
        }

        [HttpPost]
        public async Task<IActionResult> AddService(string serviceName, string description, decimal price)
        {

            var (result, message) = await _billing.createServices(serviceName, description, price);

            if (result)
            {
                return Json(message);
            }
            else
            {
                return Json("Cant Add Services");
            }


        }

    }
}
