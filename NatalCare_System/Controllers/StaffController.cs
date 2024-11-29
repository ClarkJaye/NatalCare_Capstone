using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class StaffController : BaseController<StaffController>
    {
        private readonly IProfileServices profileServices;
        private readonly ISelectListServices selectListServices;

        public StaffController(IProfileServices profileServices, ISelectListServices selectListServices, IModuleAccessServices moduleAccessServices) : base(moduleAccessServices)
        {
            this.profileServices = profileServices;
            this.selectListServices = selectListServices;
        }

        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(13))
            {
                return RedirectToDashboard();
            }

            var response = await profileServices.GetAllStaff();
            if (response.Count > 0)
            {
                return View(response);
            }
            return View();
        }


        public async Task<IActionResult> Create()
        {
            ViewData["roleStaff"] = await selectListServices.GetRoleStaffSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            ViewData["roleStaff"] = await selectListServices.GetRoleStaffSelectListAsync();
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await profileServices.CreateStaff(staff);
                    if (result)
                    {
                        TempData["success"] = "Role has been added!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (ArgumentException argEx)
                {
                    TempData["error"] = argEx.Message;
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while creating the record.";
                }
                
            }
            return View(staff);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                if (id != null)
                {
                    var result = await profileServices.DeleteStaff(id);
                    if(result.IsSuccess == true)
                    {
                        TempData["success"] = "Deleted Successfully";
                    }
                    else
                    {
                        TempData["error"] = "Deleted Failed";
                    }
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                TempData["error"] = "Staff not found!";
                return RedirectToAction(nameof(Index));
            }

            var record = await profileServices.GetStaffById(id);

            if (record == null)
            {
                TempData["error"] = "Staff not found!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["roleStaff"] = await selectListServices.GetRoleStaffSelectListAsync();
            return View(record); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            var result = await profileServices.UpdateStaff(staff);

            if (result)
            {
                TempData["success"] = "Staff has been updated!";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Staff could not be updated!";
            return View(staff);
        }




        // Helper to get current user ID
        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }

    }
}
