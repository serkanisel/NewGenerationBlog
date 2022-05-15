using System;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
	public class CategoryGetDto 
	{
        public int UserId{ get; set; }
        public int RecordCount { get; set; }
    }
}

