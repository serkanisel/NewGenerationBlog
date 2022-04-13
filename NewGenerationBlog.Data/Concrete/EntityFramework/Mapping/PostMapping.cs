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
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Posts).HasForeignKey(a => a.CategoryId).HasConstraintName("FK_Post_Category");
            builder.HasOne<User>(a => a.User).WithMany(c => c.Posts).HasForeignKey(a => a.UserId).HasConstraintName("FK_Post_User");

            builder.ToTable("Posts");

            builder.HasData(
                new Post()
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "C# 9.0 ve .net 5 yenilikleri",
                    Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",

                    Thumbnail = "Default.jpg",
                    SeoDecription = "C# 9.0 ve .net 5 yenilikleri",
                    SeoTags = "C#,C# 9, .NET5, .NET Framework, .NET Core",
                    SeoAuthor = "Serkan İşel",
                    Date = DateTime.Now,
                    UserId = 1,
                    IsDeleted = false,
                    IsPublic = false,
                    CreatedById = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ViewsCount=100
                },
            new Post()
            {
                Id = 2,
                CategoryId = 2,
                Title = "C++ nedir?",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",

                Thumbnail = "Default.jpg",
                SeoDecription = "C++ nedir?",
                SeoTags = "C++,,C",
                SeoAuthor = "Serkan İşel",
                Date = DateTime.Now,
                UserId = 1,
                IsDeleted = false,
                IsPublic = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ViewsCount=90
            },
            new Post()
            {
                Id = 3,
                CategoryId = 3,
                Title = "Javascript Nedir?",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",

                Thumbnail = "Default.jpg",
                SeoDecription = "Javascript Nedir?",
                SeoTags = "Javascript",
                SeoAuthor = "Serkan İşel",
                Date = DateTime.Now,
                UserId = 1,
                IsDeleted = false,
                IsPublic = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ViewsCount=110
            });
        }
    }
}
