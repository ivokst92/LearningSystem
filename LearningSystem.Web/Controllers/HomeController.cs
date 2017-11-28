using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Web.Models;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Models.Home;

namespace LearningSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IUserService userService;

        public HomeController(ICourseService courseService, IUserService userService)
        {
            this.userService = userService;
            this.courseService = courseService;
        }

        public IActionResult Index()
            => View(new HomeIndexViewModel()
            {
                Courses = this.courseService.Active()
            });

        public IActionResult Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel()
            {
                SearchText = model.SerachText
            };

            if (model.SearchInCourses)
            {
                viewModel.Courses = this.courseService.Find(model.SerachText);
            }

            if (model.SearchInUsers)
            {
                viewModel.Users = this.userService.Users(model.SerachText);
            }

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
