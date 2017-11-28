using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace LearningSystem.Services.Models.UserCourses
{
    public class UserListingServiceModel : IMapFrom<User>, ICustomMapping
    { 
        public string Username { get; set; }

        public string Name { get; set; }

        public int Courses { get; set; }

        public void ConfigureMapping(Profile profile)
        => profile
            .CreateMap<User, UserListingServiceModel>()
            .ForMember(u => u.Courses, cfg => cfg.MapFrom(x => x.Courses.Count));
    }
}
