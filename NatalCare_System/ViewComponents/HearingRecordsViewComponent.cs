using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class HearingRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public HearingRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            var records = await serviceServices.GetHearingRecords(patientId);
            return View(records);
        }
    }
}
