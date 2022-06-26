using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Entities.Dtos.RequestDto;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.WebAPI.Helpers;

namespace NewGenerationBlog.WebAPI.Controllers
{
	[ApiController]
    [Authorize]
	[Route("api/[controller]")]
	public class TagController  : BaseController 
	{
		private readonly ITagService _tagService;

		public TagController(ITagService tagService)
		{
			_tagService = tagService;
		}

		[HttpGet("GetUserTags")]
		public async Task<IDataResult<IList<TagDto>>> Post()
		{
			var result = await _tagService.GetUsersTag(UserId);
            return result;
		}

		[HttpPost()]
		public async Task<IResult> Post(TagAddDto tagAddDto)
		{
			tagAddDto.UserId = UserId;

			return await _tagService.AddTag(tagAddDto);
		}

		[HttpPost("TagDelete")]
		public async Task<IResult> Delete(TagAddDto tagAddDto)
		{
			return await _tagService.DeleteTag(tagAddDto);
		}

	}
}

