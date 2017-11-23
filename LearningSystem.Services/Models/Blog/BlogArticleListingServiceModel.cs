using AutoMapper;
using LearningSystem.Common.Mapping;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearningSystem.Services.Models.Blog
{
    public class BlogArticleListingServiceModel : IMapFrom<Article>, ICustomMapping
    {
        public int Id { get; set; }

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
