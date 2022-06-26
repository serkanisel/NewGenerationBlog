using System;
using System.Collections;
using NewGenerationBlog.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace NewGenerationBlog.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public Category()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public ICollection<Post> Posts {get;set;}

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
