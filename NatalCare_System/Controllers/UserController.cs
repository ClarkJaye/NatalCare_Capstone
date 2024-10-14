using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Extensions;
using NatalCare.DataAccess.Interfaces;
using NatalCare.Models.DTOs;
using NatalCare.Models.Entities;
using NatalCare.Models.ViewModel;
using PrinceQ.Utility;

namespace NatalCare_System.Controllers
{
    [Authorize]
    public class UserController : BaseController<UserController>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /User/Index
        public async Task<IActionResult> Index()
        {
            // Retrieve all users
            var users = await _userManager.Users.ToListAsync();

            // Create a list to hold users along with their roles
            var userRolesViewModel = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                // Get the roles for each user
                var roles = await _userManager.GetRolesAsync(user);

                userRolesViewModel.Add(new UserRolesViewModel
                {
                    User = user,
                    Roles = roles.ToList()
                });
            }

            return View(userRolesViewModel); // Pass the list of users with roles to the view
        }


        public IActionResult Create()
        {
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


        // GET: /User/Edit/{id}
        // GET: /User/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            var userDTO = await GetUserDtoById(id);
            if (userDTO == null)
            {
                return NotFound();
            }
            return View(userDTO);
        }

        // GET: /User/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            var userDTO = await GetUserDtoById(id);
            if (userDTO == null)
            {
                return NotFound();
            }
            return View(userDTO);
        }

        // Shared method to fetch user and roles
        private async Task<UserDTO?> GetUserDtoById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                Email = user.Email,
                Birthdate = user.Birthdate,
                Role = roles.FirstOrDefault(),
                RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name,
                    Selected = roles.Contains(x.Name)
                })
            };
        }



        // POST: /User/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                model.RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name
                });
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Update user fields
            user.FirstName = model.FirstName;
            user.MiddleName = model.MiddleName;
            user.LastName = model.LastName;
            user.Gender = model.Gender;
            user.Address = model.Address;
            user.Email = model.Email;
            user.Birthdate = model.Birthdate;

            // Update user in the database
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            // Update role
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains(model.Role) == false)
            {
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            TempData["success"] = "User has been updated!";
            return RedirectToAction(nameof(Index));
        }

        // POST: /User/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }



    }
}
