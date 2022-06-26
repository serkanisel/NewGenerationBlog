using System;
namespace NewGenerationBlog.Entities.Dtos.RequestDto
{
	public class UserRegisterDto
	{
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}

