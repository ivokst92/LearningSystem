using LearningSystem.Data;
using LearningSystem.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Models.Courses;
using AutoMapper.QueryableExtensions;

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
    }
}
