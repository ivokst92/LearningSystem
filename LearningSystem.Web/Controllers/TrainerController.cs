using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LearningSystem.Services.Interfaces;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Web.Models.Trainer;
using LearningSystem.Services.Models.Courses;
using LearningSystem.Web.Infrastructure.Extensions;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;

        private readonly UserManager<User> userManager;

        private readonly ICourseService courseService;

        public TrainerController(ITrainerService trainerService,
            UserManager<User> userManager
            , ICourseService courseService)
        {
            this.trainerService = trainerService;
            this.userManager = userManager;
            this.courseService = courseService;
        }

        public IActionResult Courses()
        {
            var userId = this.userManager.GetUserId(User);
            var courses = this.trainerService.ByTrainerId(userId);
            return View(courses);
        }

        public IActionResult Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!this.trainerService.IsTrainer(id, userId))
            {
                return NotFound();
            }

            var students = this.trainerService.StudentsInCourse(id);

            return View(new StudentsInCourseViewModel
            {
                Students = students,
                Course = this.courseService.ById<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public IActionResult GradeStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }
            var userId = this.userManager.GetUserId(User);

            if (!this.trainerService.IsTrainer(id, userId))
            {
                return BadRequest();
            }

            var success = this.trainerService.AddGrade(id, studentId, grade);
            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Grade added successfuly");
            return RedirectToAction(nameof(Students), new { id });
        }

        public async Task<IActionResult> DownloadExam(int id,string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }
            var userId = this.userManager.GetUserId(User);

            if (!this.trainerService.IsTrainer(id, userId))
            {
                return BadRequest();
            }

            var examContents = await this.trainerService.GetExamSubmission(id, studentId);

            if (examContents == null)
            {
                return BadRequest();
            }

            return File(examContents,"application/zip","Exam.zip");
        }
    }
}