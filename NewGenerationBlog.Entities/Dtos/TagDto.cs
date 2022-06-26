using System;
using System.Collections.Generic;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
	public class TagDto : DtoBase
	{
		public string Name { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

		public IList<TagPostDto> TagPosts { get; set; }
	}
}

