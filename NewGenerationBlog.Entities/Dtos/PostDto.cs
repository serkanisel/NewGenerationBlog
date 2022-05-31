using System;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
    public class PostDto  : DtoBase 
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ViewsCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public string SeoAuthor { get; set; }
        public string SeoDecription { get; set; }
        public string SeoTags { get; set; }
        public string ContentText { get; set; }
        public CategoryDto Category { get; set; }

        public UserDto User { get; set; }
    }
}
