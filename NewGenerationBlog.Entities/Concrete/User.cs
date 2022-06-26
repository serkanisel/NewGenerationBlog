using System;
using System.Collections.Generic;
using NewGenerationBlog.Shared.Entities.Abstract;

namespace NewGenerationBlog.Entities.Concrete
{
    public class User : EntityBase,IEntity
    {
        public User()
        {
        }

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

        //public int RoleId { get; set; }
        //public Role Role{ get; set; }

        public ICollection<FavoritePost> FavoritePosts { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public UserRefreshToken UserRefreshToken { get; set; }
    }
}
