using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.ViewComponents
{
    public class NewbornRecordsViewComponent : ViewComponent
    {
        private readonly INewbornServices newbornServices;

        public NewbornRecordsViewComponent(INewbornServices newbornServices)
        {
            this.newbornServices = newbornServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var records = await newbornServices.GetNewborns();
            return View(records);
        }
    }
}
