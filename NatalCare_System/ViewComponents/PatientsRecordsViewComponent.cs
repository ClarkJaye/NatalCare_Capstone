using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class PatientsRecordsViewComponent : ViewComponent
    {
        private readonly IBillingServices billingServices;

        public PatientsRecordsViewComponent(IBillingServices billingServices)
        {
            this.billingServices = billingServices;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var records = await billingServices.GetRecords();
        //    return View(records);
        //}
    }
}
