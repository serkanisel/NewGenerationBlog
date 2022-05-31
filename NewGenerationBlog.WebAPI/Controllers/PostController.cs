using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;

namespace NewGenerationBlog.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PostController : ControllerBase
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

		[HttpGet("GetAllByUserId/{userid}")]
		public async Task<IDataResult<IList<PostDto>>> GetAllByUserId(int userid)
		{
			return await _postService.GetAllByUserId(userid);
		}

		[HttpPost]
		public async Task<IDataResult<PostDto>> Post(PostAddDto postAddDto)
		{
			return await _postService.Add(postAddDto,1);
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
	}
}

