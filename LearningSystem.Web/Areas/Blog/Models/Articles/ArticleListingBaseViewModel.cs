using LearningSystem.Services.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class ArticleListingBaseViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Articles { get; set; }
    }
}
