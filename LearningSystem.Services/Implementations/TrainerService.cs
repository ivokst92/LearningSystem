using LearningSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Models.Courses;
using LearningSystem.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using LearningSystem.Services.Models.UserCourses;
using LearningSystem.Data.Models;
using System.Threading.Tasks;

namespace LearningSystem.Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext Db;

        public TrainerService(LearningSystemDbContext Db)
        {
            this.Db = Db;
        }

        public bool AddGrade(int courseId, string studentId, Grade grade)
        {
            var studentInCourse = this.Db.Find<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.Grade = grade;
            this.Db.SaveChanges();
            return true;
        }

        public IEnumerable<CourseListingServiceModel> ByTrainerId(string trainerId)
        => this.Db.Courses
            .Where(x => x.TrainerId == trainerId)
            .ProjectTo<CourseListingServiceModel>()
            .ToList();

        public async Task<byte[]> GetExamSubmission(int courseId, string studentId)
        {
            var studentInCourse = await this.Db
                .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return null;
            }

            return studentInCourse.ExamSubmission;
        }

        public bool IsTrainer(int courseId, string trainerId)
        => this.Db
            .Courses
            .Any(c => c.Id == courseId && c.TrainerId == trainerId);

        public IEnumerable<StudentInCourseServiceModel> StudentsInCourse(int courseId)
        => this.Db
            .Courses
            .Where(x => x.Id == courseId)
            .SelectMany(c => c.Students.Select(s => s.Student))
            .ProjectTo<StudentInCourseServiceModel>(new { courseId })
            .ToList();
    }
}
