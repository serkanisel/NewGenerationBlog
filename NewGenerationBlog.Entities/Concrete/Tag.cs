using System;
using System.Collections.Generic;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Concrete
{
    public class Tag : EntityBase , IEntity
    {
        public string Name { get; set; }

        public IList<TagPost> TagPosts { get; set; }
    }
}
