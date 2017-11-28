using LearningSystem.Services.Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Interfaces
{
    public interface IBlogArticleService
    {
        void Create(string title, string content, string authorId);
        IEnumerable<BlogArticleListingServiceModel> All(int page = 1);
        IEnumerable<BlogArticleListingServiceModel> ByTitleOrContent(string searchText);
        int Total();
        BlogArticleDetailsServiceModel GetById(int id);

    }
}
