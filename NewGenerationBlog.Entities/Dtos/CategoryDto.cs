using System;
using System.Collections.Generic;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
    public class CategoryDto: DtoBase 
    {
        public string Name  { get; set; }
        public string Description { get; set; }

        public IList<PostDto> Posts { get; set; }

        public User User { get; set; }
        public string Thumbnail { get; set; }

        public int PostCount { get; set; }
        public int CreatedById { get; set; }
    }
}
