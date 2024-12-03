using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.ViewComponents
{
    public class MaternalMonitoringRecordsViewComponent : ViewComponent
    {
        private readonly IServicesOperationServices serviceServices;

        public MaternalMonitoringRecordsViewComponent(IServicesOperationServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string patientId, string deliveryId)
        {
            var records = await serviceServices.GetClinicalSheetRecords(patientId, deliveryId);
            return View(records);
        }
    }
}
