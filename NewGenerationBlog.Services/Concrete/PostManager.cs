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
using System.Collections.Generic;

namespace NewGenerationBlog.Services.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public PostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<PostDto>> Add(PostAddDto postAddDto, int createdById)
        {
            try
            {
                var cat = await _unitOfWork.Categories.GetAsync(p => p.Id == postAddDto.CategoryId);

                if (cat == null)
                    return new DataResult<PostDto>(ResultStatus.Error, $"No Such Category Found", null);

                Post post = new Post();
                post.Title = postAddDto.Title;
                post.Content = postAddDto.Content;
                post.Thumbnail = postAddDto.Thumbnail;
                post.CategoryId = postAddDto.CategoryId;
                post.UserId = createdById;
                post.Thumbnail = "";
                post.SeoAuthor = "";
                post.SeoDecription = "";
                post.SeoTags = "";
                    
                await _unitOfWork.Posts.AddAsync(post);
                await _unitOfWork.SaveAsync();

                PostDto postDto = new PostDto();
                postDto.Id = post.Id;
                postDto.CreatedDate = post.CreatedDate;
                postDto.ModifiedDate = post.ModifiedDate;
                postDto.Content = post.Content;
                postDto.Title = post.Title;

                return new DataResult<PostDto>(ResultStatus.Success, $"Post Added Successfully", postDto);
            }
            catch (Exception ex)
            {
                return new DataResult<PostDto>(ResultStatus.Error, $"An Error Occured", null, ex.Message);
            }

        }

        public async Task<IResult> Delete(int postID)
        {
            var result = await _unitOfWork.Posts.AnyAsync(p => p.Id == postID);

            if (result)
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

            PostDto postDto = new PostDto();
            if (post != null)
            {
                postDto.Content = post.Content;
                postDto.CreatedDate = post.CreatedDate;
                postDto.Date = post.Date;
                postDto.Id = post.Id;
                postDto.ModifiedDate = post.ModifiedDate;
                postDto.SeoAuthor = post.SeoAuthor;
                postDto.SeoDecription = post.SeoDecription;
                postDto.SeoTags = post.SeoTags;
                postDto.Thumbnail = post.Thumbnail;
                postDto.Title = post.Title;
                postDto.ViewsCount = post.ViewsCount;

                postDto.Category = new CategoryDto();
                postDto.Category.Name = post.Category.Name;
                postDto.Category.Id = post.Category.Id;

                return new DataResult<PostDto>(ResultStatus.Success, postDto);
            }

            return new DataResult<PostDto>(ResultStatus.Error, "No Post Such Found", null);
        }

        public async Task<IDataResult<PostListDto>> GetAll()
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(null, 0, p => p.User, p => p.Category);

            if (posts.Count > -1)
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
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.CategoryId == categoryId && p.IsDeleted == false, 0,p => p.User, p => p.Category);

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
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.IsDeleted == false, 0,p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(ResultStatus.Success, new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>(ResultStatus.Error, "No Post Found", null);
        }

        public async Task<IDataResult<IList<PostDto>>> GetAllByUserId(int userId)
        {
            try
            {
                var posts = await _unitOfWork.Posts.GetAllAsync(p => p.UserId == userId && p.IsDeleted == false, 0,p => p.User, p => p.Category);

                if (posts.Count > -1)
                {
                    IList<PostDto> postDtos = new List<PostDto>();

                    foreach (var item in posts)
                    {
                        PostDto pDto = new PostDto();
                        pDto.CommentCount = item.CommentCount;
                        pDto.Content = item.Content;
                        pDto.CreatedDate = item.CreatedDate;
                        pDto.Date = item.Date;
                        pDto.ModifiedDate = item.ModifiedDate;
                        pDto.SeoAuthor = item.SeoAuthor;
                        pDto.SeoDecription = item.SeoDecription;
                        pDto.SeoTags = item.SeoTags;
                        pDto.Thumbnail = item.Thumbnail;
                        pDto.Title = item.Title;
                        pDto.ViewsCount = item.ViewsCount;

                        pDto.User = new UserDto();
                        pDto.User.Id = item.User.Id;
                        pDto.User.FirstName = item.User.FirstName;
                        pDto.User.LastName = item.User.LastName;

                        pDto.Category = new CategoryDto();
                        pDto.Category.Id = item.Category.Id;
                        pDto.Category.Name = item.Category.Name;
                        pDto.Category.Description = item.Category.Description;

                        postDtos.Add(pDto);
                    }

                    return new DataResult<IList<PostDto>>(ResultStatus.Success, null, postDtos);
                }

                return new DataResult<IList<PostDto>>(ResultStatus.Error, "No Post Found", null);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<PostDto>>(ResultStatus.Error, "An Error Occured", null, ex.Message);
            }
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
            try
            {
                Post post = await _unitOfWork.Posts.GetAsync(p => p.Id == postUpdateDto.Id);

                if(post == null)
                {
                    return new Result(ResultStatus.Error, "No Such Post Found");
                }

                post.Title = postUpdateDto.Title;
                post.Content = postUpdateDto.Content;
                post.SeoAuthor = post.SeoAuthor;
                post.SeoDecription = post.SeoDecription;
                post.SeoTags = post.SeoTags;
                post.Thumbnail = post.Thumbnail;
                post.ModifiedDate = DateTime.Now;

                await _unitOfWork.Posts.UpdateAsync(post);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Updated was successfully");
            }
            catch (Exception ex)
            {
                return new Result(ResultStatus.Error, "An Error Occured",ex.Message);
            }

        }
    }
}
