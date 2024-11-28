using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{

    public class InvoiceRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public InvoiceRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId)
        {
            var records = await serviceServices.GetDeliveryRecords(patientId);
            return View(records);
        }
    }
}
