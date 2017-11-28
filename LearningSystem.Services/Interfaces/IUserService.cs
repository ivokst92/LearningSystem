using LearningSystem.Services.Models.UserCourses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Interfaces
{
    public interface IUserService
    {
        UserProfileServiceModel Profile(string studentId);

        IEnumerable<UserListingServiceModel> Users(string searchUsers);

        Task<byte[]> GetPdfCertificate(int courseId, string studentId);
    }
}
