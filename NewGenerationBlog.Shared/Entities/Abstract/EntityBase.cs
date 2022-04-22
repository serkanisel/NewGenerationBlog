using System;
namespace NewGenerationBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
        }

        //developed by Serkan İşel
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public int CreatedById { get; set; } = 1;
    }
}
