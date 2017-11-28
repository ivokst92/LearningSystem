using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace LearningSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            var userProfile = this.userService.Profile(user.Id);
            return View(userProfile);
        }

        [Authorize]
        public async Task<IActionResult> DownloadCertificate(int id)
        {
            var studentId = this.userManager.GetUserId(User);
            var certificateContents = await this.userService
                .GetPdfCertificate(id, studentId);

            if(certificateContents == null)
            {
                return BadRequest();
            }

            return File(certificateContents, "application/pdf", "Certificate.pdf");
        }
    }
}