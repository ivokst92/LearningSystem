﻿using LearningSystem.Services.Models.Courses;
using LearningSystem.Services.Models.UserCourses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Models.Home
{
    public class SearchViewModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; } = new List<CourseListingServiceModel>();

        public IEnumerable<UserListingServiceModel> Users { get; set; } = new List<UserListingServiceModel>();

        public string SearchText { get; set; }
    }
}
