using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel.Patient;

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
        public async Task<IActionResult> Index()
        {
            // Get all counts in one call
            var (todayRecordCount, monthlyRecordCount, yearlyRecordCount) = await newbornServices.GetNewbornCountsAsync();
            // Pass counts to the view using ViewBag
            ViewBag.TodayRecord = todayRecordCount;
            ViewBag.MonthlyRecord = monthlyRecordCount;
            ViewBag.YearlyRecord = yearlyRecordCount;

            var records = await newbornServices.GetNewborns();

            return View(records ?? new List<Newborn>());

            //var record = await newbornServices.GetNewborns();
            //if(record.IsSuccess == false)
            //{
            //    TempData["error"] = record.Message;
            //    return View(record.Item);
            //}
            //return View(record.Item);
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
                var userId = GetCurrentUserId();
                var result = await newbornServices.Create(newborn, userId);

                if (result.IsSuccess == true)
                {
                    TempData["success"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(newborn);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var userId = GetCurrentUserId();
            var result = await newbornServices.Edit(id, userId);

            if (result.IsSuccess == true)
            {
                TempData["success"] = result.Message;
                return View(result.Item);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Newborn newborn)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = GetCurrentUserId();

                    var result = await newbornServices.Update(newborn, userId);

                    if (result.IsSuccess == true)
                    {
                        TempData["success"] = result.Message;
                        return RedirectToAction("Information", "Newborn", new { id = result.Item });
                    }
                }
                catch (ArgumentException argEx)
                {
                    TempData["error"] = argEx.Message;
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while updating the patient.";
                }
            }

            return View(newborn);
        }

        public async Task<IActionResult> Information(string id)
        {
            try
            {
                var response = await newbornServices.GetInformation(id);
                if (response.IsSuccess == true)
                {
                    return View(response.Item);
                }
                TempData["error"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = "An unexpected error occurred while retrieving patient information.";
            }
            return RedirectToAction(nameof(Index));
        }




        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
