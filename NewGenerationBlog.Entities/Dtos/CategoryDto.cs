using System;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
    public class CategoryDto: DtoGetBase 
    {
        public Category Category { get; set; }
    }
}
