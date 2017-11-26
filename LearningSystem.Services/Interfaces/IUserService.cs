using LearningSystem.Services.Models.UserCourses;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Interfaces
{
    public interface IUserService
    {
        UserProfileServiceModel Profile(string userId);
    }
}
