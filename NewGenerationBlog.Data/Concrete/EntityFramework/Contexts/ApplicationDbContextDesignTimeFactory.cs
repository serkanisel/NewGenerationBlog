using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NewGenerationBlog.Data.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContextDesingTimeFactory : IDesignTimeDbContextFactory<NewGenerationBlogContext>
    {
        public NewGenerationBlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NewGenerationBlogContext>();
            optionsBuilder.UseNpgsql(connectionString: @"Server=localhost;Port=5432;Database=NewGenerationBlogDB;User Id=sisel;Password=dana2314;");

            return new NewGenerationBlogContext(optionsBuilder.Options);
        }
    }
}

