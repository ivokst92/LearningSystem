using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;
using LearningSystem.Web.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using LearningSystem.Web.Infrastructure.Extensions;
using LearningSystem.Services.Models.Courses;

namespace LearningSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly UserManager<User> userManager;
        public CoursesController
            (ICourseService courseService,
            UserManager<User> userManager)
        {
            this.courseService = courseService;
            this.userManager = userManager;
        }

        public IActionResult Details(int id)
        {
            var model = new CourseDetailsViewModel()
            {
                Course = this.courseService.ById<CourseDetailsServiceModel>(id)
            };

            if (model.Course == null)
            {
                NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = userManager.GetUserId(User);
                model.StudentIsEnrolledInCourse = this.courseService.StudentIsEnrolledCourse(id,
                    userId);
            }
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult SignUp(int id)
        {
            var userId = userManager.GetUserId(User);
            var success = this.courseService.SignUpStudent(id, userId);

            if (!success)
            {
              return this.BadRequest();
            }

            TempData.AddSuccessMessage("Thank you for your registration");

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult SignOut(int id)
        {
            var userId = userManager.GetUserId(User);
            var success = this.courseService.SignOutStudent(id, userId);

            if (!success)
            {
               return this.BadRequest();
            }

            TempData.AddSuccessMessage("Sorry to see you go.");

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}