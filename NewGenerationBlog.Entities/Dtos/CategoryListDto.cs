using System;
using System.Collections.Generic;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase 
    {
        public IList<Category> Categories { get; set; }
    }
}
