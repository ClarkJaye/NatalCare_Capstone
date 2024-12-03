using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class DeliveryController : BaseController<DeliveryController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;
        private readonly ISelectListServices selectListServices;


        public DeliveryController(IPatientServices patientServices, IServicesOperationServices serviceServices, ISelectListServices selectListServices, IModuleAccessServices moduleAccessServices)
            : base(moduleAccessServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
            this.selectListServices = selectListServices;
        }

        public async Task<IActionResult> Index(string patientId, string caseno)
        {
            var patient = await patientServices.GetInformation(patientId);
            var deliveryRecord = await serviceServices.GetDeliveryRecord(patientId, caseno);
            if (deliveryRecord.CaseNo == null)
            {
                TempData["error"] = "No record found!";
                if (patient.PatientID != null)
                {
                    return RedirectToAction("MedicalRecords", "Patient", new { id = patient.PatientID });
                }
                return RedirectToAction("Index", "Patient");
            }

            var viewModel = new DeliveryRecordVM
            {
                Patient = patient,
                Delivery = deliveryRecord,
            };
            return View(viewModel);
        }

        // DELIVERY OR ADMISSION RECRDS 
        public async Task<IActionResult> DeliveryRecords(string patientId)
        {
            ViewData["newbornList"] = await selectListServices.GetAllNewbornSelectListAsync(patientId);
            ViewData["prenatalList"] = await selectListServices.GetAllPrenatalSelectListAsync(patientId);
            ViewData["dlstatusList"] = await selectListServices.GetDeliveryStatusSelectListAsync();
            return ViewComponent("DeliveryRecords", new { patientId = patientId });
        }


        //PHYSICAL EXAMINAION
        public IActionResult PERecords(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("PhysicalExaminationRecords");
        }

        //OBSTETRICAL HISTORY
        public IActionResult ObstetricalRecords(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("ObstetricalRecordsViewComponent");
        }

        //MATERNAL DELIVERY MONITORING
        public IActionResult MaternalMonitoringRecords(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("MaternalMonitoringRecordsViewComponent");
        }

        //CLINICAL SHEETS 
        public IActionResult ClinicalRecords(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("ClinicalSheetRecords");
        }


        //CLINICAL SHEETS 
        public IActionResult DischargmentRecord(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("DischargementRecords");
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
