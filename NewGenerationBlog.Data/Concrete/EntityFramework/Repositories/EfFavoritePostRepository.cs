using System;
using Microsoft.EntityFrameworkCore;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Data.Concrete.EntityFramework;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Repositories
{
	public class EfFavoritePostRepository : EfEntityRepositoryBase<FavoritePost>, IFavoritePost
	{
		public EfFavoritePostRepository(DbContext context) : base(context)
		{
		}
	}
}

