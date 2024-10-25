using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;


namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ServicessController : BaseController<ServicessController>
    {
        private readonly IServicesOperationServices crudServices;

        public ServicessController(IServicesOperationServices crudServices)
        {
            this.crudServices = crudServices;
        }

        //------ PRENATAL ------//
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
                    var result = await crudServices.AddPrenatalRecordAsync(model, patientID, userId);
                    if(result.IsSuccess)
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
                    var result = await crudServices.DeletePrenatalRecordAsync(caseNo, userId);
                    if (result.IsSuccess)
                    {
                        TempData["success"] = result.Message;
                    }
                    else
                    {
                        TempData["error"] = result.Message;
                    }
                    return Json(new { IsSuccess = result.IsSuccess });

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
                    var result = await crudServices.GetPrenatalRecordAsync(caseNo);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting prenatal record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeletePrenatalRecord." });
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
                    var result = await crudServices.UpdatePrenatalRecordAsync(model, userId);
                    if (result.IsSuccess)
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
                Logger.LogError(ex, $"Error occurred while adding prenatal record for Patient ID: {model.PatientID}");
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
                    var result = await crudServices.AddPrenatalVisitRecordAsync(model, patientID, caseNo, userId);
                    if (result.IsSuccess)
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
                Logger.LogError(ex, $"Error occurred while adding prenatal record for Patient ID: {patientID}");
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
                    var result = await crudServices.GetPrenatalVisitRecordAsync(caseNo);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting prenatal visit record for Patient");
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
                    var result = await crudServices.UpdatePrenatalVisitRecordAsync(model, userId);
                    if (result.IsSuccess)
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
                Logger.LogError(ex, $"Error occurred while adding prenatal record for Patient ID: {model.PatientID}");
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
                    var result = await crudServices.DeletePrenatalVisitRecordAsync(caseNo, userId);
                    if (result.IsSuccess)
                    {
                        TempData["success"] = result.Message;
                    }
                    else
                    {
                        TempData["error"] = result.Message;
                    }
                    return Json(new { IsSuccess = result.IsSuccess });

                }

                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting prenatal visit record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeletePrenatalVisitRecord." });
            }
        }

        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
