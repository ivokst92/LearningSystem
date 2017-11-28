using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningSystem.Web.Infrastructure.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LearningSystem.Web.Areas.Blog.Models.Articles;
using LearningSystem.Web.Infrastructure.Extensions;
using Ganss.XSS;
using LearningSystem.Services.Html;
using LearningSystem.Services.Interfaces;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService htmlService;
        private readonly IBlogArticleService blogArcticleService;
        private readonly UserManager<User> userManager;
        public ArticlesController(IHtmlService htmlService,
            IBlogArticleService blogArcticleService,
            UserManager<User> userManager)
        {
            this.blogArcticleService = blogArcticleService;
            this.htmlService = htmlService;
            this.userManager = userManager;
        }


        [AllowAnonymous]
        public IActionResult Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = this.blogArcticleService.All(page),
                TotalArticles = this.blogArcticleService.Total(),
                CurrentPage = page,
            });

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Create(PublishArticleFormViewModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            model.Content = this.htmlService.Sanitize(model.Content);
            this.blogArcticleService.Create(model.Title, model.Content, userId);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Details(int Id)
        => this.ViewOrNotFound(this.blogArcticleService.GetById(Id));

        [AllowAnonymous]
        public IActionResult Search(string SearchText)
        {
            var model = this.blogArcticleService.ByTitleOrContent(SearchText);
            return View(model);
        }
    }
}