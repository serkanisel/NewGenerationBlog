using System;
namespace NewGenerationBlog.Entities.Dtos.RequestDto
{
	public class TagAddDto
	{
        public string Name { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; } = 0;
    }
}

