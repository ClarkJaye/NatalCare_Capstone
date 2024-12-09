using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class PaymentHistoryRecordsViewComponent : ViewComponent
    {
        private readonly IBillingServices _billingServices;

        public PaymentHistoryRecordsViewComponent(IBillingServices billingServices)
        {
            _billingServices = billingServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int paymentId)
        {
            var paymentHistory = await _billingServices.GetPatientPaymentHistory(paymentId);
            return View(paymentHistory);
        }
    }
}