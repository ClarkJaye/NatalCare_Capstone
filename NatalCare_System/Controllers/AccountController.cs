using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.DTOs;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel;
using NatalCare.Utility;
using System.Security.Claims;

namespace NatalCare_System.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public  AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager, IModuleAccessServices moduleAccessServices) : base(moduleAccessServices)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
		public IActionResult AccessDenied()
		{
			return View();
		}

        public async Task<IActionResult> Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId!);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains(SD.Role_Admin))
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            if (await _userManager.IsLockedOutAsync(user))
            {
                ModelState.AddModelError("", "User is locked out. Try again after 5 minutes.");
                return View(model);
            }
            //var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: true);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Any() == true)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid credentials, please try again.");
            return View(model);
        }

        public IActionResult Register()
        {
            // Check if the roles exist, and create them using your custom Role class
            if (!_roleManager.RoleExistsAsync(SD.Role_Receptionist).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new Role { Name = SD.Role_Admin, Description = "Administrator" }).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new Role { Name = SD.Role_Staff, Description = "Staff" }).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new Role { Name = SD.Role_Receptionist, Description = "Receptionist" }).GetAwaiter().GetResult();
            }

            // Create the role list for the ViewModel
            var roleList = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            });

            var model = new UserDTO
            {
                RoleList = roleList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Birthdate = model.Birthdate,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Gender = model.Gender,
                    StatusCode = "AC",
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(model.Role))
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                    }

                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Birthdate = model.Birthdate,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Gender = model.Gender,
                    StatusCode = "AC",
                };

                var result = await _userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(model.Role))
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                    }
                    TempData["success"] = "User has been added!";
                    return RedirectToAction("Index", "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        // Get the User Profile
        [HttpGet]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = GetCurrentUserId();
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            var roles = await _userManager.GetRolesAsync(user);

            return Json(new
            {
                success = true,
                data = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.PhoneNumber,
                    user.Address,
                    Roles = roles
                }
            });
        }

        // Update Profile
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User data)
        {
            var user = await _userManager.FindByIdAsync(data.Id);

            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(data.Email);
            if (existingUser != null && existingUser.Id != data.Id)
            {
                return Json(new { success = false, message = "Email is already taken." });
            }

            // Update the user fields
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Address = data.Address;
            user.Email = data.Email;
            user.PhoneNumber = data.PhoneNumber;

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Json(new { success = true, message = "Profile updated successfully" });
            }

            Logger.LogError($"Error updating user {data.Id}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            return Json(new { success = false, message = "Failed to update profile", errors = result.Errors.Select(e => e.Description).ToArray() });
        }

        // Change Password
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword)
        {
            var userId = GetCurrentUserId();
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Json(new { success = false, message = "User not found." });
            }

            if (NewPassword != ConfirmPassword)
            {
                return Json(new { success = false, message = "New password and confirm password do not match." });
            }

            var result = await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);

            if (result.Succeeded)
            {
                return Json(new { success = true, message = "Password changed successfully." });
            }

            Logger.LogError($"Error changing password for user {userId}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            return Json(new { success = false, message = "Failed to change password", errors = result.Errors.Select(e => e.Description).ToArray() });
        }

        // Helper to get current user ID
        private string GetCurrentUserId()
        {
            return User.GetUserId();
        }


    }
}
