using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class NewbornScreeningController : BaseController<NewbornScreeningController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;

        public NewbornScreeningController(IPatientServices patientServices, IServicesOperationServices serviceServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
        }

        [HttpGet]
        public async Task<JsonResult> Get_Staff_Newborn(string id)
        {
            var userId = GetCurrentUserId();
            var result = await serviceServices.Get_Newborn(id);
            return Json(result);
        }

        //------ PRENATAL ------//
        public async Task<IActionResult> ScreeningRecords(string patientId)
        {
            var ScreeningsRecords = await serviceServices.GetScreeningRecords(patientId);
            return ViewComponent("ScreeningsRecords", new { patientId = patientId });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddScreeningRecord(NewbornScreening model, string patientID)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.ScreeningNo));

                if(model.NewbornID == null) return Json(new { IsSuccess = false, newborn = false,  Message = "select a newborn baby!" });

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddSNRecorddAsync(model, patientID, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Add Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddHRRecord." });
            }
        }
        // DELETE 
        [HttpDelete]
        public async Task<JsonResult> DeleteScreeningRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.DeleteScreeningRecordAsync(caseNo, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeleteHRRecord." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> GetScreeningRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetScreeningRecordAsync(caseNo);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while Edit  record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in EditHRRecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdateScreeningRecord(NewbornScreening model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateScreeningRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdateHRRecord." });
            }
        }


        //Display Deleted records
        public async Task<IActionResult> DisplayDeletedScreening(string patientId)
        {
            var records = await serviceServices.GetDeletedSNRecords(patientId);
            return View(records ?? new List<NewbornScreening>());
        }
      
        //Retrieved Record
        public async Task<IActionResult> RetrieveSNRecord(string caseno)
        {
            var userId = GetCurrentUserId();
            var result = await serviceServices.RetrievedSNAync(caseno, userId);
            return Json(result);

        }

        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
