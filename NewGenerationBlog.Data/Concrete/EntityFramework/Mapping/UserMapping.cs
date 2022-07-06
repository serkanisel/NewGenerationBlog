using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;


namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.Username).HasMaxLength(50);
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(200);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(50);
            builder.Property(p => p.Picture).HasMaxLength(500);
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.PasswordHash).HasColumnType("BYTEA");
            builder.Property(p => p.BirthDate).HasColumnType("DATE");
            builder.Property(p => p.Password).HasMaxLength(500);

            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("DATE");
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnType("DATE");
            builder.Property(p => p.IsDeleted).HasColumnType("BOOLEAN").IsRequired();

            builder.ToTable("Users");
        }
    }
}
