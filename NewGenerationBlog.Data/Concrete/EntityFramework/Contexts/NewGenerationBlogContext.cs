using System;
using Microsoft.EntityFrameworkCore;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Data.Concrete.EntityFramework.Mapping;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Contexts
{
    public class NewGenerationBlogContext : DbContext
    {
        public NewGenerationBlogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }

           

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(connectionString: @"Server=localhost;Port=5432;Database=NewGenerationBlogDB;User Id=sisel;Password=dana2314;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new TagPostMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

    }
}
