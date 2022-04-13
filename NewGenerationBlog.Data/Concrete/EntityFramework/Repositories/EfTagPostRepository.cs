using System;
using Microsoft.EntityFrameworkCore;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Shared.Data.Concrete.EntityFramework;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfTagPostRepository : EfEntityRepositoryBase<TagPost>, ITagPostRepository
    {
        public EfTagPostRepository(DbContext context) : base(context)
        {
        }
    }
}
