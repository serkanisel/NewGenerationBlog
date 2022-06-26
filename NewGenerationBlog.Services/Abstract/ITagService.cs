using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Entities.Dtos.RequestDto;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;

namespace NewGenerationBlog.Services.Abstract
{
	public interface ITagService
	{
		Task<IDataResult<TagDto>> GetTag(int Id);
		Task<IDataResult<IList<TagDto>>> GetUsersTag(int userId);
		Task<IResult> AddTag(TagAddDto tagAddDto);
		Task<IResult> DeleteTag(TagAddDto tagAddDto);
	}
}

