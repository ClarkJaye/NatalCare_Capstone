using Microsoft.AspNetCore.Mvc;

using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.DTOs;

namespace NatalCare_System.Controllers
{
    public class BillingController : BaseController<BillingController>
    {

        private readonly IBillingServices _billing;
        private readonly ISelectListServices selectListServices;

        public BillingController(IBillingServices billing, ISelectListServices selectListServices) { 
            _billing = billing;
            this.selectListServices = selectListServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InvoiceList()
        {
            return View();
        }

        public async Task<IActionResult> GenerateInvoice()
        {
            ViewData["staffList"] = await selectListServices.GetAllStaffSelectListAsync();

            BillingDTO billingDTO = new BillingDTO();

            return View(billingDTO);
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

        [HttpPost]
        public async Task<IActionResult> PatientSearchResult(string patientName)
        {

            var (result, list) = await _billing.searchPatient(patientName);

            if (result)
            {
                return Json(list);
            }
            else
            {
                return Json(null);
            }
        }



        
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(BillingDTO billingDTO, string action)
        {
            var (result, invoiceNumber) = await _billing.createInvoice(billingDTO);

            if (result)
            {        
                if (action == "MakePayment")
                {
                    return RedirectToAction(nameof(PrintInvoice), new { invoiceNumber });
                }
                else if (action == "SaveAndPayLater")
                {
                    return RedirectToAction(nameof(InvoiceList));
                }
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> PrintInvoice(int? invoiceNumber)
        {
            var model = await _billing.PaymentVM(invoiceNumber);

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> AllItems()
        {
            var allItems = await _billing.allItems();

            return Json(allItems);
        }

        [HttpPost]
        public async Task<IActionResult> AllServices()
        {
            var allServices = await _billing.allServices();

            return Json(allServices);
        }

    }
}
