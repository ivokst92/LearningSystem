using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace LearningSystem.Services.Models.UserCourses
{
    public class UserProfileServiceModel : IMapFrom<User>,ICustomMapping
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<UserProfileCourseServiceModel> Courses { get; set; }

        public void ConfigureMapping(Profile profile)
        => profile.CreateMap<User, UserProfileServiceModel>()
            .ForMember(u => u.Courses, cfg => cfg.MapFrom(s => s.Courses.Select(c => c.Course)));
    }
}
