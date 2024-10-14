using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class NewbornController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }

    }
}
