using System;
namespace NewGenerationBlog.Entities.Dtos.RequestDto
{
	public class SearchRequestDto
	{
        public string SearchTerm { get; set; }
        public int UserId { get; set; }
    }
}

