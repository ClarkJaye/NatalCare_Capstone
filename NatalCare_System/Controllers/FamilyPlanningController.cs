using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class FamilyPlanningController : BaseController<FamilyPlanningController>
    {
        private readonly IPatientServices patientServices;
        private readonly IServicesOperationServices serviceServices;

        public FamilyPlanningController(IPatientServices patientServices, IServicesOperationServices serviceServices)
        {
            this.patientServices = patientServices;
            this.serviceServices = serviceServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Retrieved Deleted Record
        public async Task<IActionResult> DisplayDeletedFP(string patientId)
        {
            var records = await serviceServices.GetDeletedFPRecords(patientId);
            return View(records ?? new List<FamilyPlanning>());
        }

        //Retrieved Record
        public async Task<IActionResult> RetrieveFPRecord(string caseno)
        {
            var userId = GetCurrentUserId();
            var result = await serviceServices.RetrievedFPAync(caseno, userId);
            return Json(result);
        }


        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
