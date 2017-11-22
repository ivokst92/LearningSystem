using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LearningSystem.Services.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningSystem.Web.Areas.Admin.Models.Users;
using LearningSystem.Data.Models;
using LearningSystem.Web.Infrastructure.Extensions;

namespace LearningSystem.Web.Areas.Admin.Controllers
{

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService adminUserService;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService adminUserService,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminUserService = adminUserService;
        }

        public IActionResult Index()
        {
            var users = this.adminUserService.All();
            var roles = this.roleManager
                .Roles
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            return View(new AdminUserListingsViewModel
            {
                Roles = roles,
                Users = users
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleViewModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;
            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} added to the {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }
    }
}