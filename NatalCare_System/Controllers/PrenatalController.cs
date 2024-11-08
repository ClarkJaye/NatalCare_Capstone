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

        public PrenatalController(IPatientServices patientServices, IServicesOperationServices serviceServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
        }

        public IActionResult Index()
        {
                return View();
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
