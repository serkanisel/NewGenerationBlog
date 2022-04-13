using System;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
    public class PostDto  : DtoGetBase 
    {
        public Post Post { get; set; }
    }
}
