using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class PatientController : BaseController<PatientController>
    {
        private readonly IPatientServices patientServices;

        public PatientController(IPatientServices patientServices)
        {
            this.patientServices = patientServices;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await patientServices.GetPatients();

            // Get counts for today, this month, and this year
            var todayPatientCount = await patientServices.GetTodayPatientCount();
            var monthlyPatientCount = await patientServices.GetMonthlyPatientCount();
            var yearlyPatientCount = await patientServices.GetYearlyPatientCount();

            // Pass counts to the view using ViewBag
            ViewBag.TodayPatient = todayPatientCount;
            ViewBag.MonthlyPatient = monthlyPatientCount;
            ViewBag.YearlyPatient = yearlyPatientCount;

            return View(patients ?? new List<Patients>());
        }
        public async Task<IActionResult> Information(string id)
        {
            try
            {
                var response = await patientServices.GetInformation(id);
                return View(response);
            }
            catch (ArgumentException argEx)
            {
                TempData["error"] = argEx.Message;
            }
            catch (KeyNotFoundException knfEx)
            {
                TempData["error"] = knfEx.Message;
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

        public IActionResult Payments()
        {
            return View();
        }

        public async Task<IActionResult> PrenatalRecord(string id)
        {
            var patient = await patientServices.GetInformation(id);
            var prenatalRecord = await patientServices.GetPrenatalRecord(id);
            if (prenatalRecord.CaseNo == null)
            {
                TempData["error"] = "No data found!";
                return RedirectToAction("MedicalRecords", "Patient", new { id = patient.PatientID });
            }
            var prenatalVisitRecords = await patientServices.GetPrenatalVisitsRecords(prenatalRecord.CaseNo, patient.PatientID);
            var viewModel = new PatientsVM
            {
                Patient = patient,
                PrenatalRecord = prenatalRecord,
                PrenatalVisitRecords = prenatalVisitRecords,
            };
            return View(viewModel);
        }
        public IActionResult AddFamilyPlanning()
        {
            return View();
        }

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


        [HttpGet]
        public async Task<IActionResult> GetMotherDetails(string motherID)
        {
            var mother = await patientServices.GetInformation(motherID);

            if (mother.PatientID == null)
            {
                return Json(new { isSuccess = false, Message = "Mother not found." } );
            }

            return Json(new { isSuccess = true, firstName = mother.FirstName, middleName = mother.MiddleName, lastName = mother.LastName });
        }


        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
