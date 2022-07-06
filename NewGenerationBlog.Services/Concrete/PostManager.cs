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
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HtmlAgilityPack;
using System.IO;
using NewGenerationBlog.Entities.Dtos.RequestDto;

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


                if (postAddDto.Title == null || postAddDto.Title=="")
                {
                    StringReader reader = new StringReader(postAddDto.ContentText);
                    var line = reader.ReadLine();
                    postAddDto.ContentText =  postAddDto.ContentText.Replace(line, "");
                    postAddDto.Title = line;
                    postAddDto.Thumbnail = "img" + postAddDto.Title.Substring(0, 1) + ".png";
                }

                var doc = new HtmlDocument();
                doc.LoadHtml(postAddDto.Content);

                var nodes = doc.DocumentNode.SelectNodes("//img");

                
                if (nodes!=null && nodes.Count > 0)
                {
                    var src = nodes[0].OuterHtml.Split('"');

                    foreach (var item in src)
                    {
                        if (item.Contains("http"))
                        {
                            postAddDto.Thumbnail = item;
                            break;
                        }
                    }
                }
                else
                {
                    postAddDto.Thumbnail = "img" + postAddDto.Title.Substring(0, 1).ToUpper() + ".png"; 
                }

                Post post = new Post();
                post.Title = postAddDto.Title;
                post.Content = postAddDto.Content;
                post.Thumbnail = postAddDto.Thumbnail;
                if(postAddDto.CategoryId!=0)
                post.CategoryId = postAddDto.CategoryId;
                post.UserId = createdById;
                post.Thumbnail = postAddDto.Thumbnail;
                post.SeoAuthor = "";
                post.SeoDecription = "";
                post.SeoTags = "";
                post.ContentText = postAddDto.ContentText;
                
                
                await _unitOfWork.Posts.AddAsync(post);
                await _unitOfWork.SaveAsync();

                //saving tags

                foreach (var item in postAddDto.SelectedTags)
                {
                    //check whetner exists tag
                    var tag = await _unitOfWork.Tags.GetAsync(p => p.Name == item && p.UserId == createdById);

                    if(tag==null) //not exists , save tag
                    {
                        tag = new Tag()
                        {
                            CreatedById = createdById,
                            Name = item,
                            UserId = createdById,
                            IsDeleted = false,
                        };

                        await _unitOfWork.Tags.AddAsync(tag);
                        await _unitOfWork.SaveAsync();
                    }

                    TagPost tagPost = new TagPost()
                    {
                        CreatedById = createdById,
                        IsDeleted = false,
                        PostId = post.Id,
                        TagId = tag.Id
                    };

                    await _unitOfWork.TagPosts.AddAsync(tagPost);
                    await _unitOfWork.SaveAsync();

                }

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

        public async Task<IResult> FavoritePost(int postId, int userId)
        {
            try
            {
                var post=await _unitOfWork.Posts.GetAsync(p => p.Id == postId && p.UserId == userId);

                if (post == null)
                    return new Result("No Post Found", "", HttpStatusCode.BadRequest);

                //check whetner exists favoritePost
                FavoritePost favoritePost = await _unitOfWork.FavoritePosts.GetAsync(p => p.PostId==postId && p.UserId == userId);

                if(favoritePost!=null)
                    return new Result("Post Saved as Favorite", "", HttpStatusCode.BadRequest);

                favoritePost = new FavoritePost();
                favoritePost.PostId = post.Id;
                favoritePost.UserId = post.UserId;

                await _unitOfWork.FavoritePosts.AddAsync(favoritePost);
                await _unitOfWork.SaveAsync();

                return new Result("Post Saved as Favorite", "", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return new Result("An Error Occured", ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeleteFavorite(int postId, int userId)
        {
            try
            {
                var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postId && p.UserId == userId);

                if (post == null)
                    return new Result("No Post Found", "", HttpStatusCode.BadRequest);

                //check whetner exists favoritePost
                FavoritePost favoritePost = await _unitOfWork.FavoritePosts.GetAsync(p => p.PostId == postId && p.UserId == userId);

                if (favoritePost == null)
                    return new Result("Post Is Not Favorite", "", HttpStatusCode.BadRequest);

                await _unitOfWork.FavoritePosts.DeleteAsync(favoritePost);
                await _unitOfWork.SaveAsync();

                return new Result("Post Favorite Is Deleted", "", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return new Result("An Error Occured", ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<PostDto>> Get(int postID)
        {
            var post = await _unitOfWork.Posts.GetAsync(p => p.Id == postID, p => p.User,p => p.Category,p => p.FavoritePost,p => p.TagPosts);

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

                if (post.TagPosts.Count > 0)
                    postDto.Tags = new List<TagDto>();

                foreach (var item in post.TagPosts)
                {
                    var tag = await _unitOfWork.Tags.GetAsync(p => p.Id == item.TagId);

                    TagDto tagDto = new TagDto()
                    {
                        Name = tag.Name,
                        Id = tag.Id,
                        UserId = tag.UserId
                    };

                    postDto.Tags.Add(tagDto);
                }

                if(post.FavoritePost!=null)
                {
                    postDto.FavoritePostDto = new FavoritePostDto()
                    {
                        Id = post.FavoritePost.Id,
                        PostId = post.Id,
                        UserId = post.User.Id
                    };
                }

                return new DataResult<PostDto>(postDto);
            }

            return new DataResult<PostDto>("No Post Such Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<IList<PostDto>>> GetAllByUserId(int userId)
        {
            try
            {
                var posts = await _unitOfWork.Posts.GetAllAsync(p => p.UserId == userId && p.IsDeleted == false,null,null,orderBy: (p => p.OrderByDescending(p => p.ModifiedDate)), p => p.User,p => p.Category ,p => p.FavoritePost);

                if (posts.Count() > 0)
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
                        if (item.FavoritePost != null)
                        {
                            pDto.FavoritePostDto = new FavoritePostDto()
                            {
                                Id = item.FavoritePost.Id,
                                CreatedDate = item.FavoritePost.CreatedDate,
                                UserId=item.FavoritePost.UserId,
                                PostId = item.FavoritePost.PostId
                            };
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

  

        public async Task<IDataResult<IList<PostDto>>> GetPostCountLimited(int userId, int count)
        {
            try
            {
                var posts = await _unitOfWork.Posts.GetAllAsync(predicate: p => p.UserId == userId,count, orderBy: q => q.OrderByDescending(d => d.Id),includeProperties: p => p.Category);

                IList<PostDto> postDtos = new List<PostDto>();

                foreach (var item in posts)
                {
                    PostDto pDto = new PostDto()
                    {
                        Id = item.Id,
                        CommentCount = item.CommentCount,
                        CreatedDate = item.CreatedDate,
                        Content = item.Content,
                        ContentText = item.ContentText,
                        Title = item.Title,
                        Thumbnail = item.Thumbnail,
                    };
                    

                    pDto.Category = new CategoryDto()
                    {
                        Name = item.Category.Name,
                        Id = item.Category.Id
                    };

                    postDtos.Add(pDto);
                }

                return new DataResult<IList<PostDto>>(null, postDtos, null, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<PostDto>>("An Error Occured", null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> HardDelete(int postID)
        {
            var result = await _unitOfWork.Posts.GetAsync(p => p.Id == postID);

            if (result!=null)
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
                post.CategoryId = postUpdateDto.CategoryId;

                await _unitOfWork.Posts.UpdateAsync(post);
                await _unitOfWork.SaveAsync();

                return new Result("Updated was successfully");
            }
            catch (Exception ex)
            {
                return new Result("An Error Occured",ex.Message,HttpStatusCode.InternalServerError);
            }

        }

        public async Task<IDataResult<IList<PostDto>>> GetFavoritePosts(int userId, int? count)
        {
            try
            {
                var posts = await _unitOfWork.Posts.GetAllAsync(p => p.UserId == userId && p.FavoritePost!=null && p.IsDeleted==false, count,null,orderBy: q => q.OrderByDescending(d => d.ModifiedDate) ,p => p.Category,p => p.FavoritePost);

                IList<PostDto> postDtos = new List<PostDto>();

                foreach (var item in posts)
                {
                    PostDto pDto = new PostDto()
                    {
                        Id = item.Id,
                        CommentCount = item.CommentCount,
                        CreatedDate = item.CreatedDate,
                        Content = item.Content,
                        ContentText = item.ContentText,
                        Title = item.Title,
                        Thumbnail = item.Thumbnail
                    };


                    pDto.Category = new CategoryDto()
                    {
                        Name = item.Category.Name,
                        Id = item.Category.Id
                    };

                    pDto.FavoritePostDto = new FavoritePostDto();
                    pDto.FavoritePostDto.CreatedDate = item.FavoritePost.CreatedDate;
                    pDto.FavoritePostDto.Id = item.FavoritePost.Id;
                    pDto.FavoritePostDto.PostId = item.FavoritePost.PostId;

                    postDtos.Add(pDto);
                }

                return new DataResult<IList<PostDto>>(null, postDtos, null, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<PostDto>>("An Error Occured", null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<SearchResponseDto>> Search(SearchRequestDto searchRequestDto)
        {
            try
            {
                SearchResponseDto result = new SearchResponseDto();
                var posts = await _unitOfWork.Posts.GetAllAsync(p => p.UserId == searchRequestDto.UserId && p.Title.Contains(searchRequestDto.SearchTerm));

                IList<PostDto> postDtos = new List<PostDto>();

                foreach (var item in posts)
                {
                    PostDto pDto = new PostDto()
                    {
                        Id = item.Id,
                        CommentCount = item.CommentCount,
                        CreatedDate = item.CreatedDate,
                        Content = item.Content,
                        ContentText = item.ContentText,
                        Title = item.Title,
                        Thumbnail = item.Thumbnail
                    };

                    postDtos.Add(pDto);
                }

                result.Posts = postDtos;

                return new DataResult<SearchResponseDto>(null, result, null, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<SearchResponseDto>("An Error Occured", null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
