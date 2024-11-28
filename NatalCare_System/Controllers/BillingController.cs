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

        public IActionResult PrintInvoice()
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
            var (result, message) = await _billing.createInvoice(billingDTO);

            if (result)
            {        
                if (action == "MakePayment")
                {
                    return RedirectToAction(nameof(PrintInvoice));
                }
                else if (action == "SaveAndPayLater")
                {
                    return RedirectToAction(nameof(InvoiceList));
                }
            }
            return RedirectToAction(nameof(Index));

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
