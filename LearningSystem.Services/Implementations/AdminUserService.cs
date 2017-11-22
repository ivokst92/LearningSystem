using System.Collections.Generic;
using LearningSystem.Services.Admin;
using LearningSystem.Services.Models.Admin;
using LearningSystem.Data;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace LearningSystem.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUserListingServiceModel> All()
        => this.db
            .Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToList();
    }
}
