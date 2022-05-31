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
using System.Net;

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
                if (postAddDto.CategoryId != 0)
                {
                    var cat = await _unitOfWork.Categories.GetAsync(p => p.Id == postAddDto.CategoryId);

                    if (cat == null)
                        return new DataResult<PostDto>($"No Such Category Found", null, HttpStatusCode.BadRequest);
                }

                Post post = new Post();
                post.Title = postAddDto.Title;
                post.Content = postAddDto.Content;
                post.Thumbnail = postAddDto.Thumbnail;
                if(postAddDto.CategoryId!=0)
                post.CategoryId = postAddDto.CategoryId;
                post.UserId = createdById;
                post.Thumbnail = "";
                post.SeoAuthor = "";
                post.SeoDecription = "";
                post.SeoTags = "";
                post.ContentText = postAddDto.ContentText;
                
                
                await _unitOfWork.Posts.AddAsync(post);
                await _unitOfWork.SaveAsync();

                PostDto postDto = new PostDto();
                postDto.Id = post.Id;
                postDto.CreatedDate = post.CreatedDate;
                postDto.ModifiedDate = post.ModifiedDate;
                postDto.Content = post.Content;
                postDto.Title = post.Title;

                return new DataResult<PostDto>($"Post Added Successfully", postDto);
            }
            catch (Exception ex)
            {
                return new DataResult<PostDto>($"An Error Occured", null, ex.Message,HttpStatusCode.InternalServerError);
            }

        }

        public async Task<IResult> Delete(int postID)
        {
            var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postID);

            if (post!=null)
            {
                post.IsDeleted = true;
                post.ModifiedDate = DateTime.Now;

                await _unitOfWork.Posts.UpdateAsync(post);
                await _unitOfWork.SaveAsync();

                return new Result("Post was deleted");
            }

            return new Result("No Post Such Found",HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<PostDto>> Get(int postID)
        {
            var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postID, p => p.User, p => p.Category , p => p.TagPosts);

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

                if (post.Category != null)
                {
                    postDto.Category = new CategoryDto();
                    postDto.Category.Name = post.Category.Name;
                    postDto.Category.Id = post.Category.Id;
                }

                return new DataResult<PostDto>(postDto);
            }

            return new DataResult<PostDto>("No Post Such Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<PostListDto>> GetAll()
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(null, 0, p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>( "No Post Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<PostListDto>> GetAllByCategory(int categoryId)
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.CategoryId == categoryId && p.IsDeleted == false, 0,p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>("No Post Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<PostListDto>> GetAllByNoneDeleted()
        {
            var posts = await _unitOfWork.Posts.GetAllAsync(p => p.IsDeleted == false, 0,p => p.User, p => p.Category);

            if (posts.Count > -1)
            {
                return new DataResult<PostListDto>(new PostListDto
                {
                    Posts = posts
                });
            }

            return new DataResult<PostListDto>("No Post Found", null,HttpStatusCode.BadRequest);
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
                        pDto.ContentText = item.ContentText;
                        pDto.Id = item.Id;

                        pDto.User = new UserDto();
                        pDto.User.Id = item.User.Id;
                        pDto.User.FirstName = item.User.FirstName;
                        pDto.User.LastName = item.User.LastName;

                        if (item.CategoryId != null)
                        {
                            pDto.Category = new CategoryDto();
                            pDto.Category.Id = item.Category.Id;
                            pDto.Category.Name = item.Category.Name;
                            pDto.Category.Description = item.Category.Description;
                        }
                        postDtos.Add(pDto);
                    }

                    return new DataResult<IList<PostDto>>(null, postDtos);
                }

                return new DataResult<IList<PostDto>>("No Post Found", null,HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<PostDto>>("An Error Occured", null, ex.Message,HttpStatusCode.InternalServerError);
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

                return new Result("Post was deleted from database");
            }

            return new Result("No Post Such Found",HttpStatusCode.BadRequest);
        }

        public async Task<IResult> Update(PostUpdateDto postUpdateDto)
        {
            try
            {
                Post post = await _unitOfWork.Posts.GetAsync(p => p.Id == postUpdateDto.Id);

                if(post == null)
                {
                    return new Result("No Such Post Found",HttpStatusCode.BadRequest);
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

                return new Result("Updated was successfully");
            }
            catch (Exception ex)
            {
                return new Result("An Error Occured",ex.Message,HttpStatusCode.InternalServerError);
            }

        }
    }
}
