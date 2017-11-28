using LearningSystem.Services.Models.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseListingServiceModel> Active();

        IEnumerable<CourseListingServiceModel> Find(string searchText);

        TModel ById<TModel>(int id) where TModel : class;

        bool SignUpStudent(int courseId, string studentId);

        bool StudentIsEnrolledCourse(int courseId, string studentId);

        bool SignOutStudent(int courseId, string studentId);

        Task<bool> SaveExamSubmissionAsync(int courseId, string userId, byte[] fileContents);
    }
}
