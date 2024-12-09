using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ProfileAccessController : BaseController<ProfileAccessController>
    {
        private readonly IProfileAccessServices profileAccessServices;

        public ProfileAccessController(IProfileAccessServices profileAccessServices, IModuleAccessServices moduleAccessServices) : base(moduleAccessServices)
        {
            this.profileAccessServices = profileAccessServices;
        }

        public async Task<IActionResult> Index(string id)
        {
            if (!await CheckAccessAsync(11))
            {
                return RedirectTo();
            }
            if (string.IsNullOrEmpty(id))
            {
                TempData["error"] = "Role not found!";
                return RedirectToAction("Index", "Profiles");
            }

            // Fetch profile and its access
            var (profile, roleAccess) = await profileAccessServices.GetProfileAndAccessById(id);

            if (profile == null)
            {
                TempData["error"] = "Profile not found!";
                return RedirectToAction("Index", "Profiles");
            }

            ViewData["RoleName"] = profile.Name;

            return View(roleAccess); 
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAccess(List<Role_Access> profileAccessList)
        {
            if (!await CheckAccessAsync(11))
            {
                return RedirectTo();
            }
            if (profileAccessList == null || !profileAccessList.Any())
            {
                TempData["error"] = "Access record can not update!";
                return Json(new { success = false });
            }

            // Update access records using the service
            await profileAccessServices.UpdateAccess(profileAccessList);
            TempData["success"] = "Access record updated successfully.";
            return Json(new { success = true });
        }







    }

}
