using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Interfaces;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class AdmissionController : BaseController<AdmissionController>
    {
        private readonly ISelectListServices selectListServices;

        public AdmissionController(ISelectListServices selectListServices, IModuleAccessServices moduleAccessServices)
           : base(moduleAccessServices)
        {
            this.selectListServices = selectListServices;
        }
        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(4)) 
            {
                RedirectToDashboard();
            }
            return View();
        }

        public async Task<IActionResult> Create(string id)
        {
            if (!await CheckAccessAsync(4))
            {
                RedirectToDashboard();
            }
            ViewData["triggerPatID"] = id;
            ViewData["deliveryStatus"] = await selectListServices.GetDeliveryStatusSelectListAsync();
            //ViewData["prenatalList"] = await selectListServices .GetAllPrenatalSelectListAsync(id);

            if (id != null)
            {

            }

            return View();
        }

        public async Task<IActionResult> Information()
        {
            if (!await CheckAccessAsync(4))
            {
                RedirectToDashboard();
            }
            return View();
        }


    }
}
