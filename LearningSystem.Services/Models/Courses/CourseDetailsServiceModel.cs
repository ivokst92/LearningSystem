using AutoMapper;
using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Models.Courses
{
    public class CourseDetailsServiceModel : IMapFrom<Course>, ICustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Trainer { get; set; }

        public int Students { get; set; }

        public void ConfigureMapping(Profile profile)
        => profile
            .CreateMap<Course, CourseDetailsServiceModel>()
            .ForMember(c => c.Trainer, cfg => cfg.MapFrom(c => c.Trainer.UserName))
            .ForMember(c => c.Students, cfg => cfg.MapFrom(c => c.Students.Count));
    }
}
