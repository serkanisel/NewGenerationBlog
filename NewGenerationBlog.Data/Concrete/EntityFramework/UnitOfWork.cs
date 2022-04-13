using System;
using System.Threading.Tasks;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Data.Concrete.EntityFramework.Contexts;
using NewGenerationBlog.Data.Concrete.EntityFramework.Repositories;

namespace NewGenerationBlog.Data.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly NewGenerationBlogContext _context;
        private EfPostRepository _efPostRepository;
        private EfCategoryRepository _efCategoryRepository;
        private EfRoleRepository _efRoleRepository;
        private EfTagRepository _efTagRepository;
        private EfTagPostRepository _efTagPostRepository;
        private EfUserRepository _efUserRepository;


        public UnitOfWork(NewGenerationBlogContext context)
        {
            _context = context;
            
        }

        public UnitOfWork()
        {
        }

        public IPostRepository Posts => _efPostRepository ?? new EfPostRepository(_context);

        public ICategoryRepository Categories => _efCategoryRepository ?? new EfCategoryRepository(_context);

        public ITagRepository Tags => _efTagRepository ?? new EfTagRepository(_context);

        public ITagPostRepository TagPosts => _efTagPostRepository ?? new EfTagPostRepository(_context);

        public IRoleRepository Roles => _efRoleRepository ?? new EfRoleRepository(_context);

        public IUserRepository Users => _efUserRepository ?? new EfUserRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();   
        }
    }
}
