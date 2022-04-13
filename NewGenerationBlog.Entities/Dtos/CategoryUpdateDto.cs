using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewGenerationBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required(ErrorMessage ="{0} is required")]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(70, ErrorMessage = "{0} maximum length is {1}")]
        [MinLength(3, ErrorMessage = "{0} minimum length is {1}")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        public string Description { get; set; }

        [DisplayName("Is Deleted")]
        public bool IsDeleted { get; set; }
    }
}
