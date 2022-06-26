using System;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
	public class UserRefreshTokenDto : DtoBase
	{
		public string RefreshToken { get; set; }
		public int UserId { get; set; }
		public UserDto User { get; set; }
		public bool IsActive { get; set; }
	}
}

