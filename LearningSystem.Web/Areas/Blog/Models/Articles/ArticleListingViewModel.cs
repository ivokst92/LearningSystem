using LearningSystem.Services;
using LearningSystem.Services.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class ArticleListingViewModel : ArticleListingBaseViewModel
    {   
        public string SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.PageSize);

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == TotalPages
            ? TotalPages : this.CurrentPage+1;
    }
}
