using System;
using System.Threading.Tasks;

namespace NewGenerationBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }
        ITagRepository Tags { get; }
        ITagPostRepository TagPosts { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IUserRefreshTokenRepository UserRefreshTokens { get; }
        IFavoritePost FavoritePosts { get; }
        Task<int> SaveAsync();

    }
}
