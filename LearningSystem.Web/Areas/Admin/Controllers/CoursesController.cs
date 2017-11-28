using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningSystem.Web.Areas.Admin.Models.Courses;
using LearningSystem.Web.Controllers;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Infrastructure.Extensions;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService adminCourseService;
        public CoursesController(UserManager<User> userManager, IAdminCourseService adminCourseService)
        {
            this.userManager = userManager;
            this.adminCourseService = adminCourseService;
        }

        public async Task<IActionResult> Create()
        {

            var trainersListItems = await this.GetTrainers();
            return View(new AddCourseFormViewModel()
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                Trainers = trainersListItems
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers = await this.GetTrainers();
                return View(model);
            }

            this.adminCourseService.Create(model.Name,
                model.Description,
                model.StartDate,
                model.EndDate.AddDays(1),
                model.TrainerId);

            TempData.AddSuccessMessage("Course added successfuly.");

            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty  });
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
        {
            var trainers = await userManager.GetUsersInRoleAsync(WebConstants.TrainerRole);
            return trainers.Select(x => new SelectListItem
            {
                Text = x.UserName,
                Value = x.Id
            }).ToList();
        }
    }
}