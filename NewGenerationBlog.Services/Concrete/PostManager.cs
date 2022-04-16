using System;
using System.Threading.Tasks;
using AutoMapper;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;
using NewGenerationBlog.Shared.Utilities.Results.Concrete;

namespace NewGenerationBlog.Services.Concrete
{
    public class PostManager : IPostService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public PostManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(PostAddDto postAddDto, int createdById)
        {
            var post = _mapper.Map<Post>(postAddDto);
            post.UserId = createdById;

            await _unitOfWork.Posts.AddAsync(post).ContinueWith(t => _unitOfWork.SaveAsync());

            return new Result(ResultStatus.Success,$"Post Added Successfully");
        }

        public async Task<IResult> Delete(int postID)
        {
            var result = await _unitOfWork.Posts.AnyAsync(p => p.Id == postID);

            if(result)
            {
                var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postID);

                post.IsDeleted = true;
                post.ModifiedDate = DateTime.Now;

                await _unitOfWork.Posts.UpdateAsync(post).ContinueWith(p => _unitOfWork.SaveAsync());

                return new Result(ResultStatus.Success, "Post was deleted");
            }

            return new Result(ResultStatus.Error, "No Post Such Found");
        }

        public async Task<IDataResult<PostDto>> Get(int postID)
        {
            var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postID, p => p.User, p => p.Category);
            var postDto = _mapper.Map<PostDto>(post);

            if(post != null)
            {
                return new DataResult<PostDto>(ResultStatus.Success, postDto);
            }

            return new DataResult<PostDto>(ResultStatus.Error, "No Post Such Found",null);
        }

        public async Task<IDataResult<PostListDto>> GetAll()
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(null, p => p.User, p => p.Category);

            if(posts.Count>-1)
            {
                return new DataResult<PostListDto>(ResultStatus.Success, new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>(ResultStatus.Error, "No Post Found", null);
        }

        public async Task<IDataResult<PostListDto>> GetAllByCategory(int categoryId)
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.CategoryId == categoryId && p.IsDeleted == false, p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(ResultStatus.Success, new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>(ResultStatus.Error, "No Post Found", null);
        }

        public async Task<IDataResult<PostListDto>> GetAllByNoneDeleted()
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.IsDeleted==false, p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(ResultStatus.Success, new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>(ResultStatus.Error, "No Post Found", null);
        }

        public async Task<IDataResult<PostListDto>> GetAllByUserId(int userId)
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.UserId==userId && p.IsDeleted==false, p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(ResultStatus.Success, new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>(ResultStatus.Error, "No Post Found", null);
        }

        public async Task<IResult> HardDelete(int postID)
        {
            var result = await _unitOfWork.Posts.AnyAsync(p => p.Id == postID);

            if (result)
            {
                var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postID);

                post.IsDeleted = true;
                post.ModifiedDate = DateTime.Now;

                await _unitOfWork.Posts.DeleteAsync(post).ContinueWith(p => _unitOfWork.SaveAsync());

                return new Result(ResultStatus.Success, "Post was deleted from database");
            }

            return new Result(ResultStatus.Error, "No Post Such Found");
        }

        public async Task<IResult> Update(PostUpdateDto postUpdateDto)
        {
            var post = _mapper.Map<Post>(postUpdateDto);

            post.ModifiedDate = DateTime.Now;

            await _unitOfWork.Posts.UpdateAsync(post).ContinueWith(p => _unitOfWork.SaveAsync());

            return new Result(ResultStatus.Success, "Updated was successfully");
        }
    }
}
