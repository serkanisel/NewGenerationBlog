using System.Collections.Generic;
using System.Threading.Tasks;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Entities.Dtos.RequestDto;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;

namespace NewGenerationBlog.Services.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<PostDto>> Get(int postID);
        Task<IDataResult<PostDto>> Add(PostAddDto postAddDto, int createdById);
        Task<IResult> Update(PostUpdateDto postUpdateDto);
        Task<IDataResult<IList<PostDto>>> GetAllByUserId(int userId);
        Task<IDataResult<IList<PostDto>>> GetPostCountLimited(int userId,int count);
        Task<IResult> FavoritePost(int postId,int userId);
        Task<IResult> DeleteFavorite(int postId, int userId);
        Task<IResult> Delete(int postID);
        Task<IResult> HardDelete(int postID);

        Task<IDataResult<IList<PostDto>>> GetFavoritePosts(int userId, int? count);
        Task<IDataResult<SearchResponseDto>> Search(SearchRequestDto searchRequestDto);
    }
}
