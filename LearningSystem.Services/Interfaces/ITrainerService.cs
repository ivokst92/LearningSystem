using LearningSystem.Data.Models;
using LearningSystem.Services.Models.Courses;
using LearningSystem.Services.Models.UserCourses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<CourseListingServiceModel> ByTrainerId(string trainerId);

        bool IsTrainer(int courseId, string trainerId);

        IEnumerable<StudentInCourseServiceModel> StudentsInCourse(int courseId);

        bool AddGrade(int courseId, string studentId, Grade grade);

        Task<byte[]> GetExamSubmission(int id, string studentId);
    }
}
