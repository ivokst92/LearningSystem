using LearningSystem.Data;
using LearningSystem.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Models.Courses;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data.Models;

namespace LearningSystem.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;
         
        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CourseListingServiceModel> Active()
        => this.db.Courses
            .OrderByDescending(x => x.Id)
             .Where(x => x.StartDate >= DateTime.UtcNow)
             .ProjectTo<CourseListingServiceModel>()
            .ToList();

        public TModel ById<TModel>(int id) where TModel : class
        => this.db.Courses
                 .Where(x => x.Id == id)
                 .ProjectTo<TModel>()
                 .FirstOrDefault();

        public bool SignOutStudent(int courseId, string studentId)
        {
            var courseInfo = GetCourseInfo(courseId, studentId);

            if (courseInfo == null ||
                courseInfo.StartDate < DateTime.UtcNow
                || !courseInfo.UserIsEnrolled)
            {
                return false;
            }

            var studentInCourse = this.db
                .Find<StudentCourse>(courseId,studentId);

            this.db.Remove(studentInCourse);
            this.db.SaveChanges();
            return true;
        }

        public bool SignUpStudent(int courseId, string studentId)
        {
            var courseInfo = GetCourseInfo(courseId, studentId);

            if (courseInfo == null ||
                courseInfo.StartDate < DateTime.UtcNow
                || courseInfo.UserIsEnrolled)
            {
                return false;
            }
            var studentInCourse = new StudentCourse()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            this.db.Add(studentInCourse);
            this.db.SaveChanges();
            return true;
        }

        public bool StudentIsEnrolledCourse(int courseId, string studentId)
        => this.db
            .Courses
            .Any(c => c.Id == courseId &&
            c.Students.Any(u => u.StudentId == studentId));

        private CourseWithStudentInfo GetCourseInfo(int courseId, string studentId)
        => this.db
                .Courses
                .Where(x => x.Id == courseId)
                .Select(x => new CourseWithStudentInfo
                {
                    StartDate = x.StartDate,
                    UserIsEnrolled = x.Students.Any(y => y.StudentId == studentId)
                }).FirstOrDefault();
    }
}
