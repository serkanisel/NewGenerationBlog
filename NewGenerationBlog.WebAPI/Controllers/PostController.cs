using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Services.Abstract;

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
		public async Task<IActionResult> Get(int id)
		{
			var result = await _postService.Get(id);

			return Ok(result);
		}

		[HttpGet("GetAllByUserId/{userid}")]
		public async Task<IActionResult> GetAllByUserId(int userid)
		{
			var result = await _postService.GetAllByUserId(userid);

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Post(PostAddDto postAddDto)
		{
			var result = await _postService.Add(postAddDto,1);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Put(PostUpdateDto postUpdateDto)
		{
			var result = await _postService.Update(postUpdateDto);

			return Ok(result);
		}
	}
}

