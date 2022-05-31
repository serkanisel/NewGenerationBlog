using System;
using System.ComponentModel.DataAnnotations;

namespace NewGenerationBlog.Entities.Dtos
{
	public class PostDeleteDto
	{
		[Required(ErrorMessage = "{0} is required")]
		public int Id { get; set; }
	}
}

