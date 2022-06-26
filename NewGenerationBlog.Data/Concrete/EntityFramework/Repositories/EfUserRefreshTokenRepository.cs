using System;
using Microsoft.EntityFrameworkCore;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Data.Concrete.EntityFramework;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Repositories
{
	public class EfUserRefreshTokenRepository : EfEntityRepositoryBase<UserRefreshToken>, IUserRefreshTokenRepository
	{
		public EfUserRefreshTokenRepository(DbContext context) : base(context)
		{
		}
	}
}

