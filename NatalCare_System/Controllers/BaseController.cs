    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using NatalCare.DataAccess.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NatalCare.Models.Entities;
    using NatalCare.DataAccess.data;
    using System.Data;

    namespace NatalCare_System.Controllers
    {
        public class BaseController<T> : Controller where T : class
        {
            private ILogger<T>? _logger;
            protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();

            private readonly IModuleAccessServices moduleAccessServices;

            public BaseController(IModuleAccessServices moduleAccessServices)
            {
                this.moduleAccessServices = moduleAccessServices;
            }


        protected async Task<bool> CheckAccessAsync(int moduleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return false; // User is not authenticated
            }

            var user = await moduleAccessServices.UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // User does not exist
            }

            var userRoles = await moduleAccessServices.UserManager.GetRolesAsync(user);
            var roles = await moduleAccessServices.RoleManager.Roles
                .Where(r => userRoles.Contains(r.Name))
                .ToListAsync();

            foreach (var role in roles)
            {
                if (await moduleAccessServices.HasAccessToModule(role.Id, moduleId))
                {
                    return true; // Access granted
                }
            }

            return false; // Access denied
        }



        protected IActionResult RedirectTo()
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
