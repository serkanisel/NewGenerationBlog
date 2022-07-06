using System;
using System.Collections.Generic;

namespace NewGenerationBlog.Entities.Dtos.RequestDto
{
	public class SearchResponseDto
	{
        public IList<PostDto> Posts { get; set; }
        public IList<CategoryDto> Categoires { get; set; }
        public IList<TagDto> Tags { get; set; }
    }
}

