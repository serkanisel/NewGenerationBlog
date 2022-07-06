using System;
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
	[Route("api/[controller]")]
	public class UserController : BaseController 
    {
		private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
			_userService = userService;
        }

		[HttpPost("Register")]
		public async Task<IResult> Post(UserRegisterDto userRegisterDto)
		{
			return await _userService.Register(userRegisterDto);
		}

		[HttpPost("Authenticate")]
		public async Task<IDataResult<TokenDto>> Authenticate(UserLoginDto userLoginDto)
		{
 			return await _userService.GenerateToken(userLoginDto);
		}

        [HttpPost]
        [Route("Refresh")]
		public async Task<IDataResult<TokenDto>> Refresh(TokenDto token)
        {
			return await _userService.GenerateRefresh(token);
        }

        [HttpGet]
        [Authorize]
		public async Task<IDataResult<UserDto>> Get()
        {
			return await _userService.GetUser(UserId);
        }

        [HttpGet]
        [Route("GetUsersDasboardDatas")]
        [Authorize]
        public async Task<IDataResult<UserDto>> GetUsersDashboardDatas()
        {
            var result = await _userService.GetUsersDashboardDatas(UserId);
             return result;
        }

       
    }
}

