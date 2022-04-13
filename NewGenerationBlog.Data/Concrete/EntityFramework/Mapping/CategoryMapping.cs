using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(70);
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("DATE");
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnType("DATE");
            builder.Property(p => p.IsDeleted).HasColumnType("BOOLEAN").IsRequired();

            builder.ToTable("Categories");

            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "C#",
                    Description = "C# ile ilgili en güncel bilgiler",
                    IsDeleted = false,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Category()
                {
                    Id = 2,
                    Name = "C++",
                    Description = "C++ ile ilgili en güncel bilgiler",
                    IsDeleted = false,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Category()
                {
                    Id = 3,
                    Name = "Javascript",
                    Description = "Javascript ile ilgili en güncel bilgiler",
                    IsDeleted = false,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });
        }
    }
}
