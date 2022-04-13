using System;
using Microsoft.EntityFrameworkCore;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Shared.Data.Concrete.EntityFramework;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfTagRepository : EfEntityRepositoryBase<Tag> , ITagRepository
    {
        public EfTagRepository(DbContext context) : base(context)
        {
        }
    }
}
