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

            // Get all counts in one call
            var (todayRecordCount, monthlyRecordCount, yearlyRecordCount) = await patientServices.GetPatientCountsAsync();
            // Pass counts to the view using ViewBag
            ViewBag.TodayRecord = todayRecordCount;
            ViewBag.MonthlyRecord = monthlyRecordCount;
            ViewBag.YearlyRecord = yearlyRecordCount;

            return View(patients ?? new List<Patients>());
        }

        public async Task<IActionResult> DisplayPatients()
        {
            var patients = await patientServices.GetPatients();
            return View(patients ?? new List<Patients>());
        }

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


        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
