using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class PatientController : BaseController<PatientController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;
        private readonly ISelectListServices selectListServices;

        public PatientController(IPatientServices patientServices, IServicesOperationServices serviceServices, ISelectListServices selectListServices, IModuleAccessServices moduleAccessServices)
            : base(moduleAccessServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
            this.selectListServices = selectListServices;
        }

        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(2))
            {
               return RedirectTo();
            }
            // Get all counts in one call
            var (todayRecordCount, monthlyRecordCount, yearlyRecordCount, totalCount, activeCount, inActiveCount) = await patientServices.GetPatientCountsAsync();
            // Pass counts to the view using ViewBag
            ViewBag.TodayRecord = todayRecordCount;
            ViewBag.MonthlyRecord = monthlyRecordCount;
            ViewBag.YearlyRecord = yearlyRecordCount;

            ViewBag.TotalRecord = totalCount;
            ViewBag.ActiveRecord = activeCount;
            ViewBag.InActiveRecord = inActiveCount;
            return View();
        }
        //Redirection of Each Tab
        public async Task<IActionResult> Information(string id)
        {
            try
            {
                var response = await patientServices.GetInformation(id);
                return View(response);
            }
            catch (Exception ex)
            {
                TempData["error"] = "An unexpected error occurred while retrieving patient information.";
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> MedicalRecords(string id)
        {
            ViewData["newbornList"] = await selectListServices.GetAllNewbornSelectListAsync(id);
            ViewData["prenatalList"] = await selectListServices.GetAllPrenatalSelectListAsync(id);
            ViewData["dlstatusList"] = await selectListServices.GetDeliveryStatusSelectListAsync();
            var patient = await patientServices.GetInformation(id);
            return View(patient);
        }
        public async Task<IActionResult> Payments(string id)
        {
            try
            {
                var response = await patientServices.GetInformation(id);
                return View(response);
            }
            catch (Exception ex)
            {
                TempData["error"] = "An unexpected error occurred while retrieving patient payements records.";
            }
            return RedirectToAction(nameof(Index));
        }


        //Get All Patients for In Modal
        public async Task<IActionResult> DisplayPatients()
        {
            var patients = await patientServices.GetPatients();
            return View(patients ?? new List<Patients>());
        }

        //Create Patient
        public IActionResult Create()
        {
            return View();
        }
     
        [HttpPost]
        public async Task<IActionResult> Create(Patients patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = GetCurrentUserId();
                    var result = await patientServices.Create(patient, userId);
                    if (result)
                    {
                        TempData["success"] = "Record has been added!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (ArgumentException argEx)
                {
                    TempData["error"] = argEx.Message;
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while creating the patient.";
                }
            }

            return View(patient); 
        }
       
        //Edit Patient
        public async Task<IActionResult> Edit(string id)
        {
            var userId = GetCurrentUserId();
            var result = await patientServices.Edit(id, userId);

            if(result == null)
            {
                TempData["Error"] = "An unexpected error occurred while retrieving patient";
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Patients patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = GetCurrentUserId();

                    var result = await patientServices.Update(patient, userId);

                    if (result)
                    {
                        TempData["success"] = "Record has been updated!";
                        return RedirectToAction("Information", "Patient", new {id = patient.PatientID});
                    }
                }
                catch (ArgumentException argEx)
                {
                    TempData["error"] = argEx.Message;
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while updating the patient.";
                }
            }

            return View(patient);
        }
        // DELETE 
        [HttpDelete]
        public async Task<JsonResult> Delete(string patientid)
        {
            try
            {
                if (patientid != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await patientServices.Delete(patientid, userId);

                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting family planning record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeleteFPRecord." });
            }
        }

        // Clear Spouse
        [HttpPost]
        public async Task<JsonResult> ClearSpouse(int spouseId)
        {
            try
            {
                if (spouseId > 0)
                {
                    var result = await patientServices.ClearSpouse(spouseId);
                    return Json(new { isSuccess = result.IsSuccess, message = result.Message });
                }
                return Json(new { isSuccess = true, message = "Spouse already cleared." });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting spouse record for Patient");
                return Json(new { isSuccess = false, message = "An error occurred while deleting the spouse record." });
            }
        }




        //------ Patient Records View Component ------//
        //Records
        public IActionResult GetAllPatients()
        {
            try
            {
                return ViewComponent("PatientsRecords");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in GetAllPatients action");
                return RedirectToAction(nameof(Index));
            }
        }

        //Detail Patient
        [HttpGet]
        public async Task<IActionResult> GetMotherDetails(string motherID)
        {
            var data = await patientServices.GetInformation(motherID);

            if (data.PatientID != null)
            {
                var motherData = new
                {
                    id = data.PatientID,
                    firstname = data.FirstName,
                    middlename = data.MiddleName,
                    lastname = data.LastName,
                    fatherId = data.SpouseId,
                    fFirstname = data.Spouse.FirstName,
                    fMiddlename = data.Spouse.MiddleName,
                    fLastname = data.Spouse.LastName
                };
                return Json(new { isSuccess = true, item = motherData });
            }
            return Json(new { isSuccess = false, Message = "Mother not found." } );

        }

        //Detail Patient
        [HttpGet]
        public async Task<IActionResult> GetPatientDetails(string patientId)
        {
            var data = await patientServices.GetInformation(patientId);

            if (data.PatientID != null)
            {
                var motherData = new
                {
                    id = data.PatientID,
                    firstname = data.FirstName,
                    middlename = data.MiddleName,
                    lastname = data.LastName,
                    address = data.Address,
                    birthdate = data.Birthdate,
                };
                return Json(new { isSuccess = true, item = motherData });
            }
            return Json(new { isSuccess = false, Message = "Mother not found." });

        }
        //Get All Deleted Patient
        public async Task<IActionResult> DisplayDeletedPatient()
        {
            var records = await patientServices.GetDeletedPatients();
            return View(records ?? new List<Patients>());
        }
        //Retrieved Record
        public async Task<IActionResult> RetrieveRecord(string caseno)
        {
            var userId = GetCurrentUserId();
            var result = await patientServices.RetrievedAync(caseno, userId);
            return Json(result);
        }


        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
