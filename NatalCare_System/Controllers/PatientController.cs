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

        public PatientController(IPatientServices patientServices, IServicesOperationServices serviceServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
        }

        public async Task<IActionResult> Index()
        {
            // Get all counts in one call
            var (todayRecordCount, monthlyRecordCount, yearlyRecordCount) = await patientServices.GetPatientCountsAsync();
            // Pass counts to the view using ViewBag
            ViewBag.TodayRecord = todayRecordCount;
            ViewBag.MonthlyRecord = monthlyRecordCount;
            ViewBag.YearlyRecord = yearlyRecordCount;
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


        //------ Patient Records View Component ------//
        //Records
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var PatientsRecords = await patientServices.GetPatients();
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
            var mother = await patientServices.GetInformation(motherID);

            if (mother.PatientID != null)
            {
                var motherData = new
                {
                    id = mother.PatientID,
                    firstname = mother.FirstName,
                    middlename = mother.MiddleName,
                    lastname = mother.LastName,
                };
                return Json(new { isSuccess = true, item = motherData });
            }
            return Json(new { isSuccess = false, Message = "Mother not found." } );

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
