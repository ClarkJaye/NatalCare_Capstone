using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class NewbornController : BaseController<NewbornController>
    {
        private readonly INewbornServices newbornServices;
        private readonly ISelectListServices selectListServices;

        public NewbornController(INewbornServices newbornServices, ISelectListServices selectListServices)
        {
            this.newbornServices = newbornServices;
            this.selectListServices = selectListServices;
        }
        public async Task<IActionResult> Index()
        {
            var (todayRecordCount, monthlyRecordCount, yearlyRecordCount) = await newbornServices.GetNewbornCountsAsync();
            ViewBag.TodayRecord = todayRecordCount;
            ViewBag.MonthlyRecord = monthlyRecordCount;
            ViewBag.YearlyRecord = yearlyRecordCount;

            return View();
        }

        //------ Newborn Records View Component ------//
        public async Task<IActionResult> GetAllNewborns()
        {
            try
            {
                var NewbornRecords = await newbornServices.GetNewborns();
                return ViewComponent("NewbornRecords");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in GetAllNewborns action");
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewData["midwifeList"] = await selectListServices.GetMidwifeSelectListAsync();
            ViewData["staffList"] = await selectListServices.GetStaffSelectListAsync();
            ViewData["physicianList"] = await selectListServices.GetPhysicianSelectListAsync();


            return View();
        }
        // CREATE 
        [HttpPost]
        public async Task<IActionResult> Create(Newborn newborn)
        {
            ViewData["midwifeList"] = await selectListServices.GetMidwifeSelectListAsync();
            ViewData["staffList"] = await selectListServices.GetStaffSelectListAsync();
            ViewData["physicianList"] = await selectListServices.GetPhysicianSelectListAsync();
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
            ViewData["midwifeList"] = await selectListServices.GetMidwifeSelectListAsync();
            ViewData["staffList"] = await selectListServices.GetStaffSelectListAsync();
            ViewData["physicianList"] = await selectListServices.GetPhysicianSelectListAsync();

            var userId = GetCurrentUserId();
            var result = await newbornServices.Edit(id, userId);

            if (result.IsSuccess == true)
            {
                return View(result.Item);
            }
            return RedirectToAction(nameof(Index));

        }
        // EDIT 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Newborn newborn)
        {
            try
            {
                ViewData["midwifeList"] = await selectListServices.GetMidwifeSelectListAsync();
                ViewData["staffList"] = await selectListServices.GetStaffSelectListAsync();
                ViewData["physicianList"] = await selectListServices.GetPhysicianSelectListAsync();

                if (ModelState.IsValid)
                {
                    var userId = GetCurrentUserId();
                    var result = await newbornServices.Update(newborn, userId);
                    if (result.IsSuccess == true)
                    {
                        TempData["success"] = result.Message;
                        return RedirectToAction("Information", "Newborn", new { id = result.Item });
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex + "= An error occurred while updating the patient.";
            }
            return View(newborn);
        }
        // DELETE 
        [HttpDelete]
        public async Task<JsonResult> Delete(string newbornId)
        {
            try
            {
                if (newbornId != null)
                {
                    var userId = GetCurrentUserId();
                    var result = await newbornServices.Delete(newbornId, userId);

                    return Json(result);
                }
                return Json(new { IsSuccess = false, Message = "Delete Record failed!" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error occurred while deleting family planning record for Patient");
                return Json(new { IsSuccess = false, Message = "An error occurred in DeleteFPRecord." });
            }
        }
        //INFORMATION
        public async Task<IActionResult> MedicalRecords(string id)
        {
            var newborn = await newbornServices.GetGeneralInformation(id);
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
                TempData["error"] = ex + "= An unexpected error occurred while retrieving patient information.";
            }
            return RedirectToAction(nameof(Index));
        }

        //Get All Deleted NEWBORN
        public async Task<IActionResult> DisplayDeletedNewborn()
        {
            var records = await newbornServices.GetDeletedNewborns();
            return View(records ?? new List<Newborn>());
        }

        //Retrieved Record
        public async Task<IActionResult> RetrieveRecord(string nbid)
        {
            var userId = GetCurrentUserId();
            var result = await newbornServices.RetrievedAync(nbid, userId);
            return Json(result);
        }



        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
