using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class OPDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Information()
        {
            return View();
        }


    }
}
