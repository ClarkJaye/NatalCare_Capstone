using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class PrenatalController : BaseController<PrenatalController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;

        public PrenatalController(IPatientServices patientServices, IServicesOperationServices serviceServices, IModuleAccessServices moduleAccessServices) : base(moduleAccessServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
        }

        public IActionResult Index()
        {
                return View();
        }

        //------ PRENATAL ------//
        //Records
        public async Task<IActionResult> PrenatalFormRecords(string prenatalId)
        {
            try
            {
                if (prenatalId != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetPrenatalFormRecordAsync(prenatalId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while getting prenatal visit detailed record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in         public async Task<IActionResult> PrenatalFormRecords(string patientId)\r\n." });
            }
        }
        public IActionResult PrenatalRecords(string patientId)
        {
            return ViewComponent("PrenatalRecords", new { patientId = patientId });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddPrenatalRecord(Prenatal model, string patientID)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.CaseNo));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddPrenatalRecordAsync(model, patientID, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Add Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding prenatal record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddPrenatalRecord." });
            }
        }
        // DELETE 
        [HttpDelete]
        public async Task<JsonResult> DeletePrenatalRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.DeletePrenatalRecordAsync(caseNo, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting prenatal record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeletePrenatalRecord." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> EditPrenatalRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetPrenatalRecordAsync(caseNo);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while Edit prenatal record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in EditPrenatalRecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdatePrenatalRecord(Prenatal model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdatePrenatalRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the prenatal record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdatePrenatalRecord." });
            }
        }

        //------ PRENATAL VISIT ------//
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddPrenatalVisitRecord(PrenatalVisit model, string patientID, string caseNo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddPrenatalVisitRecordAsync(model, patientID, caseNo, userId);
                    if(result.IsSuccess == true)
                    {
                        TempData["success"] = result.Message;
                    }
                    else
                    {
                        TempData["error"] = result.Message;
                    }
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Add Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding prenatal visit record for Patient ID: {patientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddPrenatalRecord." });
            }
        }

        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> DetailPrenatalVisitRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetPrenatalVisitRecordAsync(caseNo);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while getting prenatal visit detailed record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DetailPrenatalVisitRecord." });
            }
        }

        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdatePrenatalVisitRecord(PrenatalVisit model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdatePrenatalVisitRecordAsync(model, userId);
                    if (result.IsSuccess == true)
                    {
                        TempData["success"] = result.Message;
                    }
                    else
                    {
                        TempData["error"] = result.Message;
                    }
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating prenatal visit record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdatePrenatalRecord." });
            }
        }

        // DELETE 
        [HttpDelete]
        public async Task<JsonResult> DeletePrenatalVisitRecord(string caseNo)
        {
            try
            {
                if (caseNo != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.DeletePrenatalVisitRecordAsync(caseNo, userId);
                    return Json(result);
                }

                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting prenatal visit record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeletePrenatalVisitRecord." });
            }
        }


        //Records
        public async Task<IActionResult> PrenatalRecord(string patientid, string caseno)
        {
            var patient = await patientServices.GetInformation(patientid);
            var prenatalRecord = await serviceServices.GetPrenatalRecord(patientid, caseno);
            if (prenatalRecord.CaseNo == null)
            {
                TempData["error"] = "No record found!";
                if(patient.PatientID != null)
                {
                    return RedirectToAction("MedicalRecords", "Patient", new { id = patient.PatientID });
                }
                return RedirectToAction(nameof(Index));
            }
            var prenatalVisitRecords = await serviceServices.GetPrenatalVisitsRecords(prenatalRecord.CaseNo, patient.PatientID);
            var viewModel = new PatientsVM
            {
                Patient = patient,
                PrenatalRecord = prenatalRecord,
                PrenatalVisitRecords = prenatalVisitRecords,
            };
            return View(viewModel);
        }

        //Display Deleted records
        public async Task<IActionResult> DisplayDeletedPrenatal(string patientId)
        {
            var records = await serviceServices.GetDeletedPrenatalRecords(patientId);
            return View(records ?? new List<Prenatal>());
        }
      
        //Retrieved Record
        public async Task<IActionResult> RetrievePrenatalRecord(string caseno)
        {
            var userId = GetCurrentUserId();
            var result = await serviceServices.RetrievedPrenetalAync(caseno, userId);
            return Json(result);

        }

        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
