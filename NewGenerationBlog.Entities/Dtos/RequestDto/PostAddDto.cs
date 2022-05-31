using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Entities.Dtos
{
    public class PostAddDto
    {
        [DisplayName("Title")]
        [Required(ErrorMessage ="{0} is required")]
        [MaxLength(500, ErrorMessage ="Maximum length is 500 caracters.")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 caracters.")]
        public string Title { get; set; }

        [MinLength(20, ErrorMessage = "Minimum length is 20 caracters.")]
        public string Content { get; set; }

        //[Required(ErrorMessage = "{0} is required)")]
        //[MaxLength(250, ErrorMessage = "Maximum length is 250 caracters.")]
        //[MinLength(5, ErrorMessage = "Minimum length is 5 caracters.")]
        public string Thumbnail { get; set; }

        //[Required(ErrorMessage = "{0} is required)")]
        //[MaxLength(50, ErrorMessage = "Maximum length is 250 caracters.")]
        //[MinLength(0, ErrorMessage = "Minimum length is 5 caracters.")]
        public string SeoAuthor { get; set; }

        //[Required(ErrorMessage = "{0} is required)")]
        //[MaxLength(150, ErrorMessage = "Maximum length is 250 caracters.")]
        //[MinLength(0, ErrorMessage = "Minimum length is 5 caracters.")]
        public string SeoDescription { get; set; }

        //[Required(ErrorMessage = "{0} is required)")]
        //[MaxLength(70, ErrorMessage = "Maximum length is 250 caracters.")]
        //[MinLength(0, ErrorMessage = "Minimum length is 5 caracters.")]
        public string SeoTags { get; set; }

        public int CategoryId { get; set; }

        public string ContentText { get; set; }
    }
}
