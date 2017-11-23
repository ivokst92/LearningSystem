using LearningSystem.Common.Mapping;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearningSystem.Services.Models.Courses
{
    public class CourseListingServiceModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseNameMaxLength)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
