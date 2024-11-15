using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class DeliveryController : BaseController<DeliveryController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;

        public DeliveryController(IPatientServices patientServices, IServicesOperationServices serviceServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
        }

        public IActionResult Index()
        {
                return View();
        }

        public IActionResult DeliveryRecords(string patientId)
        {
            return ViewComponent("DeliveryRecords", new { patientId = patientId });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddDeliveryRecord(Delivery model, string patientID)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.CaseNo));
                ModelState.Remove(nameof(model.NewbornID));
                ModelState.Remove(nameof(model.PrenatalID));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddDeliveryRecordAsync(model, patientID, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Add Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding prenatal record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in Add Delivery Record." });
            }
        }
        // DELETE 
        [HttpDelete]
        public async Task<JsonResult> DeleteDeliveryRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.DeleteDeliveryRecordAsync(caseNo, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting delivery record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in Delete Delivery Record." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> EditDeliveryRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetDeliveryRecordAsync(caseNo);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while Edit delivery record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in Edit Delivery Record." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdateDeliveryRecord(Delivery model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateDeliveryRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the delivery record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdateDeliveryRecord." });
            }
        }


        //Display Deleted records
        [HttpGet]
        public async Task<IActionResult> DisplayDeletedDelivery(string patientId)
        {
            var records = await serviceServices.GetDeletedDeliveryRecords(patientId);
            return View(records ?? new List<Delivery>());
        }
      
        //Retrieved Record
        public async Task<IActionResult> RetrieveDeliveryRecord(string caseno)
        {
            var userId = GetCurrentUserId();
            var result = await serviceServices.RetrievedDeliveryAync(caseno, userId);
            return Json(result);

        }

        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
