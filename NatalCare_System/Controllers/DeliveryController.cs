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


        /////////////////PHYSICAL EXAMINAION
        public IActionResult PERecords(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("PhysicalExaminationRecords", new { patientId = patientId, deliveryId = caseno });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddPEForm(PhysicalExamination model, string patientID, string deliveryID)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.CaseNo));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddPERecordAsync(model, patientID, userId, deliveryID);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid Record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddPEForm." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> GetPERecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetPhysicalExaminationRecord(id);
                        return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the Physical examination record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in EditPERecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdatePERecord(PhysicalExamination model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdatePERecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the psycial examination record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdatePERecord." });
            }
        }


        ///////////////OBSTETRICAL HISTORY
        public IActionResult ObstetricalRecords(string patientId, string caseno)
        {
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("ObstetricalRecords", new { patientId = patientId, deliveryId = caseno });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddOBForm(Obstetrical model, string patientID, string deliveryID)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.CaseNo));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddOBRecordAsync(model, patientID, userId, deliveryID);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid Record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddOBForm." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> GetOBRecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetOBRecord(id);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the obstetrical record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in GetOBRecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdateOBRecord(Obstetrical model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateOBRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the obstetrical record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdateOBRecord." });
            }
        }



        //////////////MATERNAL DELIVERY MONITORING
        public async Task<IActionResult> MaternalMonitoringRecords(string patientId, string caseno)
        {
            ViewData["allStaffList"] = await selectListServices.GetAllStaffSelectListAsync();

            ViewData["DeliveryId"] = caseno;
            return ViewComponent("MaternalMonitoringRecords", new { patientId = patientId, deliveryId = caseno });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddMDForm(MaternalMonitoring model, string patientID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddMDRecordAsync(model, patientID, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid Record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding clinical sheet record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddCFForm." });
            }
        }
        public async Task<JsonResult> AddPLForm(ProgressLabor model, string patientID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddPLRecordAsync(model);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid Record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding proress labor for Patient ID: {patientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddPLForm." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> GetMDRecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetMDRecord(id);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the maternal record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in GetMDRecord." });
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetPLRecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetPLRecord(id);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the progress labor for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in GetPLRecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdateMDRecord(MaternalMonitoring model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateMDRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the maternal record record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdateCFRecord." });
            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdatePLRecord(ProgressLabor model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdatePLRecordAsync(model);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the progress labor record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdatePLRecord." });
            }
        }
        //Delete Progress Labor
        [HttpDelete]
        public async Task<JsonResult> DeletePLRecord(int deleteId)
        {
            try
            {
                if (deleteId > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.DeletePLRecordAsync(deleteId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the progress labor for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeletePLRecord." });
            }
        }

        ///////////////CLINICAL SHEETS 
        public async Task<IActionResult> ClinicalRecords(string patientId, string caseno)
        {
            ViewData["midwifeList"] = await selectListServices.GetMidwifeSelectListAsync();

            ViewData["DeliveryId"] = caseno;
            return ViewComponent("ClinicalSheetRecords", new { patientId = patientId, deliveryId = caseno });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddCFForm(ClinicalFaceSheet model, string patientID, string caseno)
            {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.CaseNo));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddCFRecordAsync(model, patientID, userId, caseno);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid Record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding clinical sheet record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddCFForm." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> GetCFRecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetCFRecord(id);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the clinical record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in GetCFRecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdateRecord(ClinicalFaceSheet model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateCFRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Update Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the clinical sheet record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdateCFRecord." });
            }
        }
        // GET AOG last Data 
        public async Task<JsonResult> GetAOGDataLast(string caseno)
        {
            if (caseno != null)
            {
                var result = await serviceServices.GetAOGLast(caseno);
                return Json(result);
            }
            return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
        }




        ///////////////DISCHARGEMENT FORM
        public async Task<IActionResult> DischargmentRecord(string patientId, string caseno)
        {
            ViewData["midwifeList"] = await selectListServices.GetMidwifeSelectListAsync();
            ViewData["allStaffList"] = await selectListServices.GetAllStaffSelectListAsync();
            
            ViewData["DeliveryId"] = caseno;
            return ViewComponent("DischargementRecords", new { patientId = patientId, deliveryId = caseno });
        }
        //ADD 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddDFForm(DischargementForm model, string patientID, string caseno)
        {
            try
            {
                // Exclude CaseNo from validation
                ModelState.Remove(nameof(model.CaseNo));

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.AddDFRecordAsync(model, patientID, userId, caseno);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid Record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while adding record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in AddDFForm." });
            }
        }
        // GET/EDIT 
        [HttpGet]
        public async Task<JsonResult> GetDFRecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.GetDFRecord(id);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Fetching Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while get the dischargement record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in GetDFRecord." });
            }
        }
        // UPDATE
        [HttpPost]
        public async Task<JsonResult> UpdateDFRecord(DischargementForm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await serviceServices.UpdateDFRecordAsync(model, userId);
                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Invalid record!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while updating the dichargement record for Patient ID: {model.PatientID}");
                return Json(new { IsSuccess = false, Message = "An error occurred in UpdateDFRecord." });
            }
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
