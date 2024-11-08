using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class FamilyPlanningRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public FamilyPlanningRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            var records = await serviceServices.GetFamilyPlanningRecords(patientId);
            return View(records);
        }
    }
}
