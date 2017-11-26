using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace LearningSystem.Services.Models.UserCourses
{
    public class UserProfileCourseServiceModel : IMapFrom<Course>, ICustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            string studentId = null;
            profile.CreateMap<Course, UserProfileCourseServiceModel>()
                .ForMember(p => p.Grade, cfg =>
                cfg.MapFrom(p => p.Students.Where(s => s.StudentId == studentId)
                  .Select(x => x.Grade)
                  .FirstOrDefault()));
        }
    }
}
