using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Shared.Data.Abstract;
using NewGenerationBlog.Shared.Data.Concrete.EntityFramework;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfPostRepository : EfEntityRepositoryBase<Post>, IPostRepository
    {
        public EfPostRepository(DbContext context) : base(context)
        {

        }
    }
}
