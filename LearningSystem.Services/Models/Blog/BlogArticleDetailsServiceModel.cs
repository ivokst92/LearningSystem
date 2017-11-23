using LearningSystem.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LearningSystem.Data.Models;
using System.ComponentModel.DataAnnotations;
using LearningSystem.Data;

namespace LearningSystem.Services.Models.Blog
{
    public class BlogArticleDetailsServiceModel : IMapFrom<Article>, ICustomMapping
    {

        [Required]
        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength()]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile profile)
        => profile.CreateMap<Article, BlogArticleDetailsServiceModel>()
         .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
