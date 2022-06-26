using System;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Concrete
{
	public class UserRefreshToken  : EntityBase, IEntity
	{
		public UserRefreshToken()
		{
		}

        public string RefreshToken { get; set; }

        public int UserId { get; set; }
		public User User { get; set; }

		public bool IsActive { get; set; }
    }
}

