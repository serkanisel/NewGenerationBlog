using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(500);
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("DATE");
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnType("DATE");
            builder.Property(p => p.IsDeleted).HasColumnType("BOOLEAN").IsRequired();

            builder.ToTable("Roles");
        }
    }
}
