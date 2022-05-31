using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Entities.Dtos
{
    public class PostUpdateDto
    {
        [Required(ErrorMessage = "{0} is required)")]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "{0} is required)")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 caracters.")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 caracters.")]
        public string Title { get; set; }

        [MinLength(20, ErrorMessage = "Minimum length is 20 caracters.")]
        public string Content { get; set; }

        public string ContentText { get; set; }
    }
}
