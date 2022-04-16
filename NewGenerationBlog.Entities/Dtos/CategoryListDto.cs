using System;
using System.Collections.Generic;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;

namespace NewGenerationBlog.Entities.Dtos
{
    public class CategoryListDto
    {
        public IList<CategoryDto> Categories { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }
}
