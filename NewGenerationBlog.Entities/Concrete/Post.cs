using System;
using System.Collections.Generic;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Concrete
{
    public class Post : EntityBase,IEntity 
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentText { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ViewsCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public string SeoAuthor { get; set; }
        public string SeoDecription { get; set; }
        public string SeoTags { get; set; }
        public bool IsPublic { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IList<TagPost> TagPosts { get; set; }
    }
}
