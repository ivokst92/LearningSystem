using LearningSystem.Services.Models.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseListingServiceModel> Active();
    }
}
