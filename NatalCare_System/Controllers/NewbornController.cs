using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class NewbornController : Controller
    {
        private readonly INewbornServices newbornServices;

        public NewbornController(INewbornServices newbornServices)
        {
            this.newbornServices = newbornServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Newborn newborn)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = GetCurrentUserId();
                    var result = await newbornServices.Create(newborn, userId);

                    if (result)
                    {
                        TempData["success"] = "Record has been added!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (ArgumentException argEx)
                {
                    TempData["error"] = argEx.Message;
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while creating the newborn.";
                }
            }

            return View(newborn);
        }

        public IActionResult Information()
        {
            return View();
        }


        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
