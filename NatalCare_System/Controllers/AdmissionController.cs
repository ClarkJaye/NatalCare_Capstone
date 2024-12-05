using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class AdmissionController : BaseController<AdmissionController>
    {
        private readonly ISelectListServices selectListServices;
        private readonly IServicesOperationServices serviceServices;
        private readonly ICountServices countservices;

        public AdmissionController(ICountServices countservices, IServicesOperationServices serviceServices, ISelectListServices selectListServices, IModuleAccessServices moduleAccessServices)
           : base(moduleAccessServices)
        {
            this.serviceServices = serviceServices;
            this.selectListServices = selectListServices;
            this.countservices = countservices;
        }
        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(4)) 
            {
                return RedirectTo();
            }

            // Get all counts in one call
            var (totalAdmitted, totalInLabor, totalPospartum) = await countservices.GetAdmissionCountsAsync();
            // Pass counts to the view using ViewBag
            ViewBag.TotalAdmitted = totalAdmitted;
            ViewBag.TotalInLabor = totalInLabor;
            ViewBag.TotalPospartum = totalPospartum;


            var patients = await serviceServices.GetAllDeliveryRecords();
            return View(patients ?? new List<Delivery>());
        }

        public async Task<IActionResult> Create(string id)
        {
            if (!await CheckAccessAsync(4))
            {
                return RedirectTo();
            }
            ViewData["triggerPatID"] = id;
            ViewData["deliveryStatus"] = await selectListServices.GetDeliveryStatusSelectListAsyncExceptReferral();
            ViewData["wardList"] = await selectListServices.GetWardsSelectListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Delivery model)
        {
            if (!await CheckAccessAsync(4))
            {
                return RedirectTo();
            }

            if (ModelState.IsValid)
            {
                var userId = GetCurrentUserId();
                var result = await serviceServices.AddAdmissionDelivery(model, userId);
                if (result.IsSuccess == true)
                {
                    TempData["success"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
            

        public async Task<IActionResult> Edit(string id, string patid)
        {
            if (!await CheckAccessAsync(4))
            {
                return RedirectTo();
            }
            ViewData["triggerPatID"] = patid;
            ViewData["deliveryStatus"] = await selectListServices.GetDeliveryStatusSelectListAsync();
            ViewData["wardList"] = await selectListServices.GetWardsSelectListAsync();
            var userId = GetCurrentUserId();
            var result = await serviceServices.GetAdmittedDeliveryRecord(id);
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id, string patid)
        {
            if (!await CheckAccessAsync(4))
            {
                return RedirectTo();
            }
            ViewData["triggerPatID"] = patid;
            ViewData["deliveryStatus"] = await selectListServices.GetDeliveryStatusSelectListAsync();
            ViewData["wardList"] = await selectListServices.GetWardsSelectListAsync();
            var userId = GetCurrentUserId();
            var result = await serviceServices.GetAdmittedDeliveryRecord(id);
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Delivery model)
        {
            if (!await CheckAccessAsync(4))
            {
                return RedirectTo();
            }

            if (ModelState.IsValid)
            {
                var userId = GetCurrentUserId();
                var result = await serviceServices.UpdateAdmissionDelivery(model, userId);
                if (result.IsSuccess == true)
                {
                    TempData["success"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }




        // HELPER 
        public async Task<JsonResult> GetBedNumber(int wardId)
        {
            var data = await selectListServices.GetBedsSelectListAsync(wardId);
            if(data == null)
            {
                return Json(new { isSuccess = false, item = "No data found!" });
            }
            return Json(new { isSuccess = true, item = data.Items });
        }

        public async Task<JsonResult> GetBedNumberorEdit(int wardId)
        {
            var data = await selectListServices.GetAllBedSelectListAsync(wardId);
            if (data == null)
            {
                return Json(new { isSuccess = false, item = "No data found!" });
            }
            return Json(new { isSuccess = true, item = data.Items });
        }



        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }
    }
}
