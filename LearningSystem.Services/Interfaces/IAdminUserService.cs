using LearningSystem.Services.Models.Admin;
using System.Collections.Generic;

namespace LearningSystem.Services.Admin
{
    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();
    }
}
