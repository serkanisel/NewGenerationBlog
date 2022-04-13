using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
    public class TagPostMapping : IEntityTypeConfiguration<TagPost>
    {
        public void Configure(EntityTypeBuilder<TagPost> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("DATE");
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnType("DATE");
            builder.Property(p => p.IsDeleted).HasColumnType("BOOLEAN").IsRequired();

            builder.HasOne(p => p.Post).WithMany(c => c.TagPosts).HasForeignKey(p => p.PostId);
            builder.HasOne(p => p.Tag).WithMany(c => c.TagPosts).HasForeignKey(p => p.TagId);

            builder.ToTable("TagPosts"); 

        }
    }
}
