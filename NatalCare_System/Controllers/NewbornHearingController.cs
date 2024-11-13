using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class NewbornHearingController : BaseController<NewbornHearingController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;

        public NewbornHearingController(IPatientServices patientServices, IServicesOperationServices serviceServices)
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

        //------ HEARING ------//
        public async Task<IActionResult> HearingRecords(string patientId)
        {
            var HearingRecords = await serviceServices.GetHearingRecords(patientId);
            return ViewComponent("HearingRecords", new { patientId = patientId });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddHRRecord(NewbornHearing model, string patientID)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.HearingNo));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddHRRecordAsync(model, patientID, userId);
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
        public async Task<JsonResult> DeleteHRRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.DeleteHRRecordAsync(caseNo, userId);
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
        public async Task<JsonResult> GetHRRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetHRRecordAsync(caseNo);
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
        public async Task<JsonResult> UpdateHRRecord(NewbornHearing model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateHRRecordAsync(model, userId);
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
        public async Task<IActionResult> DisplayDeletedHearing(string patientId)
        {
            var records = await serviceServices.GetDeletedHRRecords(patientId);
            return View(records ?? new List<NewbornHearing>());
        }
      
        //Retrieved Record
        public async Task<IActionResult> RetrieveHearingRecord(string caseno)
        {
            var userId = GetCurrentUserId();
            var result = await serviceServices.RetrievedHRAync(caseno, userId);
            return Json(result);

        }

        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
