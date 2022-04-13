using System.Threading.Tasks;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;

namespace NewGenerationBlog.Services.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<PostDto>> Get(int postID);
        Task<IDataResult<PostListDto>> GetAll();
        Task<IDataResult<PostListDto>> GetAllByNoneDeleted();
        Task<IDataResult<PostListDto>> GetAllByCategory(int categoryId);
        Task<IResult> Add(PostAddDto postAddDto, int createdById);
        Task<IResult> Update(PostUpdateDto postUpdateDto);
        Task<IDataResult<PostListDto>> GetAllByUserId(int userId);

        Task<IResult> Delete(int postID);
        Task<IResult> HardDelete(int postID);
    }
}
