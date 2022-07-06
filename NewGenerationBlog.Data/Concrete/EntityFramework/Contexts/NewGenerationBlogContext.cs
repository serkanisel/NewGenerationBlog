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
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<FavoritePost> FavoritePosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(connectionString: @"Server=localhost;Port=5433;Database=MindDrawerDB2;User Id=postgres;Password=danaveli2314;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCollation("case_insensitive_collation", locale: "en-u-ks-primary", provider: "icu", deterministic: false);

            modelBuilder.HasPostgresExtension("citext");
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new TagPostMapping());
            modelBuilder.ApplyConfiguration(new TagMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserRefreshTokenMapping());
            modelBuilder.ApplyConfiguration(new FavoritePostMapping());
        }

    }
}
