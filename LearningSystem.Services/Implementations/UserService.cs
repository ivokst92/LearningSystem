using LearningSystem.Data;
using LearningSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Models.UserCourses;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace LearningSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext Db;

        public UserService(LearningSystemDbContext Db)
        {
            this.Db = Db;
        }

        public UserProfileServiceModel Profile(string userId)
        => this.Db.Users
            .Where(x => x.Id == userId)
            .ProjectTo<UserProfileServiceModel>(new {studentId = userId })
            .FirstOrDefault();
    }
}
