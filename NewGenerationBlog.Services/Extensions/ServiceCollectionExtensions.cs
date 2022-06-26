using System;
using Microsoft.Extensions.DependencyInjection;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Data.Concrete.EntityFramework;
using NewGenerationBlog.Data.Concrete.EntityFramework.Contexts;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Services.Concrete;

namespace NewGenerationBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection LoadMyServices (this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext <NewGenerationBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IPostService, PostManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<ITagService, TagManager>();
            return serviceCollection;
        }
    }
}
