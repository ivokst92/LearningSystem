using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearningSystem.Data.Models
{
    public class Article
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

        public User Author { get; set; }
    }
}
