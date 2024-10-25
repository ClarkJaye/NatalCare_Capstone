using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class FamilyPlanningRecordsViewComponent : ViewComponent
    {
        private readonly IPatientServices patientServices;

        public FamilyPlanningRecordsViewComponent(IPatientServices patientServices)
        {
            this.patientServices = patientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            var records = await patientServices.GetPrenatalRecords(patientId);
            return View(records);
        }
    }
}
