using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ReportsController : BaseController<ReportsController>
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
