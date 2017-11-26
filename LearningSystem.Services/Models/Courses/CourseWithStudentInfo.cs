using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Models.Courses
{
    public class CourseWithStudentInfo
    {
        public DateTime StartDate { get; set; }
        public bool UserIsEnrolled { get; set; }
    }
}
