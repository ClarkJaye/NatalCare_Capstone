using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class PrenatalRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public PrenatalRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            var records = await serviceServices.GetPrenatalRecords(patientId);
            return View(records);
        }
    }
}
