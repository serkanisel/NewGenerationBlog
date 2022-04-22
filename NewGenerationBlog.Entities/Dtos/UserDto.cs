using System;
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
        public string Picture { get; set; }
        public string Description { get; set; }
    }
}

