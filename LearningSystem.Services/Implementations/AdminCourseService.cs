using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Implementations
{
    public class AdminCourseService : IAdminCourseService
    {
        private readonly LearningSystemDbContext db;
        public AdminCourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string desciption, DateTime startDate, DateTime endDate, string trainerId)
        {
            var course = new Course()
            {
                Description = desciption,
                EndDate = endDate,
                Name = name,
                StartDate = startDate,
                TrainerId = trainerId
            };

            this.db.Courses.Add(course);
            this.db.SaveChanges();
        }
    }
}
