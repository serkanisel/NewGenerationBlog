using System;
using System.Collections;
using System.Collections.Generic;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Dtos
{
	public class UserDto : DtoBase 
	{
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public ICollection<PostDto> FavoritePosts { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public ICollection<TagDto> Tags { get; set; }

    }
}

