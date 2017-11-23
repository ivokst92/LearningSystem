using LearningSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
    public class AddCourseFormViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.CourseDescriptionMaxLength)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Trainer")]
        [Required]
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date should be from the future");
            }

            if (StartDate > EndDate)
            {
                yield return new ValidationResult("Start date should be before end date.");
            }
        }
    }
}
