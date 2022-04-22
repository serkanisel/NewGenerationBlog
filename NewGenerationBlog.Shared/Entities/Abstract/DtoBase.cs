using System;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;

namespace NewGenerationBlog.Shared.Entities.Abstract
{
    public abstract class DtoBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } 
        public virtual DateTime ModifiedDate { get; set; }
    }
}
