using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewGenerationBlog.Data.Concrete.EntityFramework.Contexts;
using NewGenerationBlog.Entities.Concrete;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Data
{
    public class Seed
    {
        public static async Task SeedData(NewGenerationBlogContext context)
        {
            
            User u1 = new User();
            u1.Id = 1;
//            u1.RoleId = 7;
            u1.FirstName = "Serkan";
            u1.LastName = "İşel"; 
            u1.Username = "sisel";
            u1.Email = "serkanisel@gmail.com";
                u1.IsDeleted = false;
            u1.CreatedById = 1;
            u1.CreatedDate = DateTime.Now;
            u1.ModifiedDate = DateTime.Now;
            u1.BirthDate = Convert.ToDateTime("1980-10-23");
            u1.Description = "Owner Of the system";
            u1.Mobile = "532 586 6292";
            u1.Picture = "";
            u1.PasswordHash = Encoding.ASCII.GetBytes("1024b3486faaede8904e4fe56aff2ff1");
            
            if (!context.Users.Any())
            {
                await context.Users.AddAsync(u1);
                await context.SaveChangesAsync();
            }

            Category cat1 = new Category()
            {
                Name = "C#",
                Description = "C# ile ilgili en güncel bilgiler",
                IsDeleted = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserId = u1.Id
            };

            Category cat2 = new Category()
            {
                Name = "C++",
                Description = "C++ ile ilgili en güncel bilgiler",
                IsDeleted = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserId = u1.Id
            };

            Category cat3 = new Category()
            {
                Name = "Javascript",
                Description = "Javascript ile ilgili en güncel bilgiler",
                IsDeleted = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserId = u1.Id
            };
            if (!context.Categories.Any())
            {
                await context.Categories.AddAsync(cat1);
                await context.Categories.AddAsync(cat2);
                await context.Categories.AddAsync(cat3);
                await context.SaveChangesAsync();
            }

            Post p1 = new Post()
            {
                CategoryId = cat1.Id,
                Title = "C# 9.0 ve .net 5 yenilikleri",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",

                Thumbnail = "Default.jpg",
                SeoDecription = "C# 9.0 ve .net 5 yenilikleri",
                SeoTags = "C#,C# 9, .NET5, .NET Framework, .NET Core",
                SeoAuthor = "Serkan İşel",
                Date = DateTime.Now,
                UserId = u1.Id,
                IsDeleted = false,
                IsPublic = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ViewsCount = 100
            };

            Post p2 = new Post()
            {
                CategoryId = cat2.Id,
                Title = "C++ nedir?",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",

                Thumbnail = "Default.jpg",
                SeoDecription = "C++ nedir?",
                SeoTags = "C++,,C",
                SeoAuthor = "Serkan İşel",
                Date = DateTime.Now,
                UserId = u1.Id,
                IsDeleted = false,
                IsPublic = false,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ViewsCount = 90
            };
            Post p3 = new Post()
            {
                CategoryId = cat3.Id,
                Title = "Javascript Nedir?",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",

                Thumbnail = "Default.jpg",
                SeoDecription = "Javascript Nedir?",
                SeoTags = "Javascript",
                SeoAuthor = "Serkan İşel",
                Date = DateTime.Now,
                UserId = u1.Id,
                IsDeleted = false,
                IsPublic = false,
                ViewsCount = 110
            };
            if (!context.Posts.Any())
            {
                await context.Posts.AddAsync(p1);
                await context.Posts.AddAsync(p2);
                await context.Posts.AddAsync(p3);
                await context.SaveChangesAsync();
            }
        }
    }
}

