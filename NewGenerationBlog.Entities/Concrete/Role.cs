using System;
using System.Collections.Generic;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        public Role()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
