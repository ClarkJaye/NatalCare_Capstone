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

        public PatientController(IPatientServices patientServices)
        {
            this.patientServices = patientServices;
        }

        public async Task<IActionResult> Index()
        {
            var response = await patientServices.GetPatients();
            if(response.Count > 0 )
            {
                return View(response);
            }
            // Ensure the view always receives a list, even if it's empty
            return View(response ?? new List<Patients>());
        }

        public IActionResult Information()
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
            if (!ModelState.IsValid)
            {
                var userid = GetCurrentUserId();
                var result = await patientServices.Create(patient, userid);

                if (result)
                {
                    TempData["success"] = "Record has been added!";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(patient);
        }

        // Helper to get current user ID
        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }

    }
}
