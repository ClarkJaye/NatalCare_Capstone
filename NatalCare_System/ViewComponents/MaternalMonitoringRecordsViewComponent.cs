using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.ViewModel.Patient;

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
            // Fetch records
            var maternalRecord = await serviceServices.GetMaternalMonitoringRecords(patientId, deliveryId);
            var progressLaborRecord = await serviceServices.GetProgressLaborRecords(deliveryId);


            // Combine into a view model
            var viewModel = new MaternalMonitoringVM
            {
                MaternalMonitoring = maternalRecord,
                ProgressLabor = progressLaborRecord
            };

            // Pass the view model to the view
            return View(viewModel);
        }
    }
}
