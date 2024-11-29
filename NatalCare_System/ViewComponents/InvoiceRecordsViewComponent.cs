using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{

    public class InvoiceRecordsViewComponent : ViewComponent
    {
        private readonly IBillingServices serviceServices;

        public InvoiceRecordsViewComponent(IBillingServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var records = await serviceServices.GetPayments();
            return View(records);
        }
    }
}
