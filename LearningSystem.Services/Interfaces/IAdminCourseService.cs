using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Interfaces
{
    public interface IAdminCourseService
    {
        void Create(string name,string desciption,DateTime startDate,DateTime endDate,string trainerId);
    }
}
