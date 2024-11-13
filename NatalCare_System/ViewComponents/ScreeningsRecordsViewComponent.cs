using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class ScreeningsRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public ScreeningsRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            var records = await serviceServices.GetScreeningRecords(patientId);
            return View(records);
        }
    }
}
