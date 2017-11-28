using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Models.Home
{
    public class SearchFormModel
    {
        public string SerachText { get; set; }

        [Display(Name = "Search In Users")]
        public bool SearchInUsers { get; set; } = true;

        [Display(Name = "Search In Courses")]
        public bool SearchInCourses { get; set; } = true;
    }
}
