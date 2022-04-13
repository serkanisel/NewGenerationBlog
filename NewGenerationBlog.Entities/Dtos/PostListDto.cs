using System;
using System.Collections.Generic;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
    public class PostListDto : DtoGetBase
    {
        public IList<Post> Posts { get; set; }
    }
}
