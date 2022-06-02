using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne<User>(a => a.User).WithMany(c => c.Tags).HasForeignKey(a => a.UserId).HasConstraintName("FK_Tag_User");

            builder.ToTable("Tags");
        }
    }
}

