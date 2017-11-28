using LearningSystem.Data;
using LearningSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Models.UserCourses;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using LearningSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext Db;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(LearningSystemDbContext Db,
            IPdfGenerator pdfGenerator)
        {
            this.pdfGenerator = pdfGenerator;
            this.Db = Db;
        }

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            var studentInCourse = await this.Db
                .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return null;
            }

            var data = await this.Db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    CourseName =c.Name,
                    CourseStartDate = c.StartDate,
                    CourseEndDate= c.EndDate,
                    StudentName = c.Students.Where(x=>x.StudentId == studentId)
                    .Select(x=>x.Student.Name).FirstOrDefault(),
                    StudentGrade =c.Students.Where(x=>x.StudentId==studentId)
                    .Select(x=>x.Grade).FirstOrDefault(),
                    TrainerName = c.Trainer.Name
                })
                .FirstOrDefaultAsync();

            return this.pdfGenerator.GeneratePdfFromHtml(string.Format(
                ServiceConstants.PdfCertificateFormat,
                data.StudentName,
                data.CourseName,
                data.StudentGrade,
                data.TrainerName,
                data.CourseStartDate.ToShortDateString(),
                data.CourseEndDate.ToShortDateString()));
        }

        public UserProfileServiceModel Profile(string userId)
        => this.Db.Users
            .Where(x => x.Id == userId)
            .ProjectTo<UserProfileServiceModel>(new { studentId = userId })
            .FirstOrDefault();

        public IEnumerable<UserListingServiceModel> Users(string searchUsers)
        {
            searchUsers = searchUsers ?? string.Empty;
            return this.Db.Users
                .OrderBy(u => u.UserName)
                .Where(x => x.UserName.ToLower().Contains(searchUsers.ToLower()))
                .ProjectTo<UserListingServiceModel>()
                .ToList();
        }
    }
}
