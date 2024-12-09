using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.Entities;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class ProfilesController : BaseController<ProfilesController>
    {
        private readonly IProfileServices profileServices;

        public ProfilesController(IProfileServices profileServices, IModuleAccessServices moduleAccessServices)
            : base(moduleAccessServices)
        {
            this.profileServices = profileServices;
        }

        public async Task<IActionResult> Index()
        {
            if (!await CheckAccessAsync(11))
            {
                return RedirectTo();
            }

            var response = await profileServices.GetProfiles();
            if (response.Count > 0)
            {
                return View(response);
            }
            return View();
        }


        public async Task<IActionResult> Create()
        {
            if (!await CheckAccessAsync(11))
            {
                return RedirectTo();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role profile)
        {
            if (ModelState.IsValid)
            {
                var userId = GetCurrentUserId();
                var result = await profileServices.Create(profile, userId);

                if (result)
                {
                    TempData["success"] = "Role has been added!";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                TempData["error"] = "Role not found!";
            }

            var userId = GetCurrentUserId(); 
            var result = await profileServices.Delete(id, userId);

            if (result)
            {
                TempData["success"] = "Role has been deleted!";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Role could not be deleted!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["error"] = "Role not found!";
                return RedirectToAction(nameof(Index));
            }

            var profile = await profileServices.GetProfileById(id);

            if (profile == null)
            {
                TempData["error"] = "Profile not found!";
                return RedirectToAction(nameof(Index));
            }

            return View(profile); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Role profile)
        {
            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            var userId = GetCurrentUserId();
            var result = await profileServices.UpdateProfile(profile, userId);

            if (result)
            {
                TempData["success"] = "Profile has been updated!";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Profile could not be updated!";
            return View(profile);
        }






        // Helper to get current user ID
        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }

    }
}
