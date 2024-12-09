using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class DeliveryRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public DeliveryRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            ViewData["patientId"] = patientId;
            var records = await serviceServices.GetDeliveryRecords(patientId);
            return View(records);
        }
    }
}
