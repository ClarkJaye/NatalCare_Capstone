using Microsoft.AspNetCore.Mvc;

using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Services;
using NatalCare.Models.DTOs;
using NatalCare.Models.DTOs.VM;
using NatalCare.Models.Entities;

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


                    //VIEW

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InvoiceList()
        {
            return View();
        }


        public async Task<IActionResult> PayInvoice(int? id, decimal? balance)
        {

            ViewBag.PaymentId = id;

            ViewBag.Balance = balance;

            var patientId = await _billing.patientID(id);

            ViewBag.PatientId = patientId;

           var model = await _billing.payInvoice();

            return View(model);
        }

        public async Task<IActionResult> EditInvoice(int? id)
        {

            ViewBag.PaymentId = id;

            var model = await _billing.payInvoice();

            return View(model);
        }


        public async Task<IActionResult> Payment(int? id, decimal? balance)
        {
            if (id != null)
            {
                ViewBag.PaymentId = id;

                ViewBag.Balance = balance;

                var patientId = await _billing.patientID(id);

                ViewBag.PatientId = patientId;

                return View();
            }
            else
            {
                return RedirectToAction(nameof(InvoiceList));
            }

        }

        public async Task<IActionResult> PrintInvoice(int? id)
        {
            var model = await _billing.PaymentVM(id);

            return View(model);
        }


        public async Task<IActionResult> GenerateInvoice(int? id)
        {
            ViewData["staffList"] = await selectListServices.GetAllStaffSelectListAsync();

            var model = await _billing.generateInvoiceModel(id);

            return View(model);

        }



        //LOGIC

        //WALA PA
        [HttpPost]
        public async Task<IActionResult> editPatientPayment(PatientPayments patientPayments)
        {
            if (patientPayments != null)
            {

                var (result, message) = await _billing.editPatientPayment(patientPayments);

                if (result)
                {
                    return RedirectToAction(nameof(InvoiceList));
                }

                return View();
            }
            else
            {
                return RedirectToAction(nameof(InvoiceList));
            }


        }



        [HttpPost]
        public async Task<IActionResult> AddPatientPayment(PatientPayments patientPayments)
        {
            if (patientPayments != null)
            {

                var (result, message) = await _billing.addPatientPayment(patientPayments);

                if (result)
                {
                    return RedirectToAction(nameof(InvoiceList));
                }

                return View();
            }
            else
            {
                return RedirectToAction(nameof(InvoiceList));
            }
   

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

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int itemId)
        {

            var (result, message) = await _billing.deleteItem(itemId);

            if (result)
            {
                return Json(message);
            }
            else
            {
                return Json("Cant Delete Item");
            }


        }

        

        [HttpPost]
        public async Task<IActionResult> EditItem(int id, string itemName, string description, decimal price)
        {

            var (result, message) = await _billing.editItems(id, itemName, description, price);

            if (result)
            {
                return Json(message);
            }
            else
            {
                return Json("Cant Update Item");
            }

        }


        [HttpPost]
        public async Task<IActionResult> EditService(int id, string serviceName, string description, decimal price)
        {

            var (result, message) = await _billing.editServices(id, serviceName, description, price);

            if (result)
            {
                return Json(message);
            }
            else
            {
                return Json("Cant Update Services");
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
        public async Task<IActionResult> CreateInvoice(BillingAndPrintVM billingAndPrint, string action)
        {
            if (action == "Save")
            {
                var (result, id) = await _billing.editInvoice(billingAndPrint.BillingDTO);

                if (result)
                {
                    return RedirectToAction(nameof(InvoiceList));

                }
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var (result, id) = await _billing.createInvoice(billingAndPrint.BillingDTO);

                if (result)
                {
                    if (action == "MakePayment")
                    {
                        return RedirectToAction(nameof(PrintInvoice), new { id });
                    }
                    else if (action == "SaveAndPayLater")
                    {
                        return RedirectToAction(nameof(InvoiceList));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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

        [HttpDelete]
        public async Task<JsonResult> DeletePayment(int paymentId)
        {
            try
            {
                if (paymentId != null)
                {

                    var (result, message) = await _billing.deleyePayment(paymentId);

                    if (result)
                    {
                        return Json(message);

                    }

                }
                return Json(new { IsSuccess = false, Message = "Delete Payment failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting family planning record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeleteFPRecord." });
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePatientPayment(int paymentId)
        {
            try
            {
                if (paymentId != null)
                {

                    var (result, message) = await _billing.deletePatientPayment(paymentId);

                    if (result)
                    {
                        return Json(message);
                    }

                    return Json(null);

                }
                return Json(new { IsSuccess = false, Message = "Delete Payment failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting family planning record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeleteFPRecord." });
            }

        }

        [HttpGet]
        public async Task<JsonResult> GetDataByYearAndMonthPaymentStatistics(int? year, string? month)
        {
            try
            {
                var response = await _billing.GetDataByYearAndMonth(year, month);
                return Json(new { IsSuccess = true, Data = response });
            }
            catch (Exception ex)
            {
                // Log the exception
                return Json(new { IsSuccess = false, Message = "An error occurred while fetching data." });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetPaymentStatusStatistics()
        {
            try
            {
                var response = await _billing.GetPaymentStatusStatistics();
                return Json(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return Json(new { IsSuccess = false, Message = "An error occurred while fetching data." });
            }
        }

        
    }
}
