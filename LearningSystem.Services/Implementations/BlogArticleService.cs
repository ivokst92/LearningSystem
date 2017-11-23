using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Models.Blog;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace LearningSystem.Services.Implementations
{
    public class BlogArticleService : IBlogArticleService
    {
        private readonly LearningSystemDbContext db;
        public BlogArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BlogArticleListingServiceModel> All(int page = 1)
        => this.db.Articles
            .OrderByDescending(x => x.PublishDate)
            .Skip((page - 1) * ServiceConstants.PageSize)
            .Take(ServiceConstants.PageSize)
            .ProjectTo<BlogArticleListingServiceModel>()
            .ToList();

        public void Create(string title, string content, string authorId)
        {
            var article = new Article()
            {
                AuthorId = authorId,
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow
            };
            this.db.Articles.Add(article);
            this.db.SaveChanges();
        }

        public BlogArticleDetailsServiceModel GetById(int id)
        => this.db.Articles
            .Where(x => x.Id == id)
            .ProjectTo<BlogArticleDetailsServiceModel>()
            .First();

        public int Total()
        => this.db.Articles.Count();
    }
}
