using System;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
	public class FavoritePostDto : DtoBase
	{
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }

        public int PostId { get; set; }
        public int PostDto { get; set; }
    }
}

