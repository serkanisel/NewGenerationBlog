using System;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Data.Abstract;

namespace NewGenerationBlog.Data.Abstract
{
    public interface ITagRepository : IEntityRepository<Tag>
    {
    }
}
