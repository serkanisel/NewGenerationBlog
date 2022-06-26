using System;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
	public class TagPostDto : DtoBase
	{
        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public TagDto Tag { get; set; }
        public int TagId { get; set; }
    }
}

