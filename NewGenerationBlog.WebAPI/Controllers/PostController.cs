using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.WebAPI.Helpers;
using HtmlAgilityPack;
using NewGenerationBlog.Entities.Dtos.RequestDto;

namespace NewGenerationBlog.WebAPI.Controllers
{
	[ApiController]
    [Authorize]
	[Route("api/[controller]")]
	public class PostController : BaseController
	{
		private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
			_postService = postService;
        }

		[HttpGet("{id}")]
		public async Task<IDataResult<PostDto>> Get(int id)
		{
			return await _postService.Get(id);
		}

		[HttpGet("GetAllByUserId")]
		public async Task<IDataResult<IList<PostDto>>> GetAllByUserId()
		{
			return await _postService.GetAllByUserId(UserId);
		}

		[HttpGet]
        [Route("GetAllByUserIdWithCount/{count}")]
		public async Task<IDataResult<IList<PostDto>>> GetAllByUserIdWithCount(int count)
		{
			return await _postService.GetPostCountLimited(UserId,count);
		}

		[HttpPost]
		public async Task<IDataResult<PostDto>> Post(PostAddDto postAddDto)
		{
            return await _postService.Add(postAddDto,UserId);
		}

		[HttpPut]
		public async Task<IResult> Put(PostUpdateDto postUpdateDto)
		{
			return await _postService.Update(postUpdateDto);
		}

		[HttpPost("SoftDelete")]
		public async Task<IResult> SoftDelete(PostDeleteDto postDeleteDto)
		{
			return await _postService.Delete(postDeleteDto.Id);
		}

		[HttpPost]
		[Route("Favorite/{postid}")]
		public async Task<IResult> Favorite(int postid)
		{
			return await _postService.FavoritePost(postid, UserId);
		}

        [HttpPost]
        [Route("DeleteFavorite/{postid}")]
        public async Task<IResult> DeleteFavorite(int postid)
        {
            return await _postService.DeleteFavorite(postid, UserId);
        }

        [HttpGet]
		[Route("GetFavoritePosts/{count}")]
		public async Task<IDataResult<IList<PostDto>>> GetFavoritePosts(int? count)
		{
			return await _postService.GetFavoritePosts(UserId,count);
		}

        [HttpPost]
        [Route("TryParsing")]
        public IActionResult TryParsing(PostAddDto postAddDto)
        {
			var doc = new HtmlDocument();
			doc.LoadHtml(postAddDto.Content);

			string name = doc.DocumentNode.SelectNodes("//img").First().Attributes["value"].Value;
            return Ok(name);
        }

        [HttpPost]
        [Route("Search")]
        [Authorize]
        public async Task<IDataResult<SearchResponseDto>> Search(SearchRequestDto searchRequestDto)
        {
			searchRequestDto.UserId = UserId;
            var result = await _postService.Search(searchRequestDto);
            return result;
        }
    }
}

