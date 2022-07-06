using System;
using System.Threading.Tasks;
using NewGenerationBlog.Entities.Dtos.RequestDto;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using System.Security.Claims;
using NewGenerationBlog.Entities.Dtos;

namespace NewGenerationBlog.Services.Abstract
{
	public interface IUserService
	{
		public Task<IResult> Register(UserRegisterDto userRegisterDto);
		public Task<IDataResult<TokenDto>> GenerateToken(UserLoginDto userLoginDto);
		public Task<IDataResult<TokenDto>> GenerateRefresh(TokenDto tokenDto);
		public Task<IDataResult<UserDto>> GetUser(int UserId);
		public Task<IDataResult<UserDto>> GetUsersDashboardDatas(int userId);
    }
}

