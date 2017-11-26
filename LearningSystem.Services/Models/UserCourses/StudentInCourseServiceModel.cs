using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace LearningSystem.Services.Models.UserCourses
{
    public class StudentInCourseServiceModel : IMapFrom<User>, ICustomMapping
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            int courseId = default(int);
            profile.CreateMap<User, StudentInCourseServiceModel>()
                .ForMember(s => s.Grade, cfg => cfg.MapFrom(u => u.Courses
                    .Where(c => c.CourseId == courseId) 
                    .Select(g => g.Grade).FirstOrDefault()));
        }
    }
}
