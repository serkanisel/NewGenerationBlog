using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("TEXT");

            builder.Property(a => a.ContentText).IsRequired();
            builder.Property(a => a.ContentText).HasColumnType("TEXT");

            builder.Property(a => a.Date).IsRequired(true);
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDecription).IsRequired();
            builder.Property(a => a.SeoDecription).HasMaxLength(150);
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);

            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("DATE");
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnType("DATE");
            builder.Property(p => p.IsDeleted).HasColumnType("BOOLEAN").IsRequired();
            builder.Property(p => p.IsPublic).HasColumnType("BOOLEAN").IsRequired();


            //foreing keys
            builder.HasOne<User>(a => a.User).WithMany(c => c.Posts).HasForeignKey(a => a.UserId).HasConstraintName("FK_Post_User");
            builder.HasOne<FavoritePost>(a => a.FavoritePost).WithOne(r => r.Post).HasForeignKey<FavoritePost>(t => t.PostId).HasConstraintName("FK_Post_FavoritePost");
            builder.ToTable("Posts");
        }
    }
}
