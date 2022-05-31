using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewGenerationBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        public string Description { get; set; }
    }
}
