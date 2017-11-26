using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Services.Models.Courses;

namespace LearningSystem.Web.Models.Courses
{
    public class CourseDetailsViewModel
    {
        public CourseDetailsServiceModel Course { get; set; }
        public bool StudentIsEnrolledInCourse { get; set; }
    }
}
