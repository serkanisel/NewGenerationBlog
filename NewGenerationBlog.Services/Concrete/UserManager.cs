using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Entities.Dtos.RequestDto;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Services.Helpers;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Concrete;

namespace NewGenerationBlog.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IPostService _postService;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper,ICategoryService categoryService,ITagService tagService,IPostService postService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryService = categoryService;
            _tagService = tagService;
            _postService = postService;
        }

        public Task<IDataResult<TokenDto>> Login(UserLoginDto userLoginDto)
        {

            return null;
        }

        public async Task<IResult> Register(UserRegisterDto userRegisterDto)
        {

            try
            {
                //check user whetner exists same username or email
                var userSearch = await _unitOfWork.Users.GetAsync(p => p.Username == userRegisterDto.Username || p.Email == userRegisterDto.Email);

                if (userSearch != null)
                {
                    return new Result("User Already Exists,Please pick another username and email", null, HttpStatusCode.BadRequest);
                }

                User user = new User();
                user.FirstName = userRegisterDto.FirstName;
                user.LastName = userRegisterDto.LastName;
                user.Username = userRegisterDto.Username;
                user.Password = ComputeSha256Hash(userRegisterDto.Password);
                user.PasswordHash = ComputeSha256HashRaw(userRegisterDto.Password);
                user.BirthDate = userRegisterDto.BirthDate;
                user.Email = userRegisterDto.Email;

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return new Result("User Registered");
            }
            catch (Exception ex)
            {
                return new Result("An error occured", ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<TokenDto>> GenerateToken(UserLoginDto userLoginDto)
        {
            try
            {
                string passHash = ComputeSha256Hash(userLoginDto.Password);

                //check user exists
                User user = await _unitOfWork.Users.GetAsync(p => p.Username == userLoginDto.UserName && p.Password == passHash);

                if (user == null)
                {
                    return new DataResult<TokenDto>("No user found", null, HttpStatusCode.BadRequest);
                }

                TokenDto tokenDto = GenerateToken(user.Username, user.Id);

                await SaveUserRefreshToken(user.Id, tokenDto.Refresh_Token);

                return new DataResult<TokenDto>("", tokenDto, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<TokenDto>(ex.Message, null, HttpStatusCode.InternalServerError);
            }
        }

        async Task SaveUserRefreshToken(int userId, string refresh_token)
        {
            var userRefreshToken = await _unitOfWork.UserRefreshTokens.GetAsync(p => p.UserId == userId
            && p.IsActive == true);

            //delete user refresh token
            if (userRefreshToken != null)
            {
                await _unitOfWork.UserRefreshTokens.DeleteAsync(userRefreshToken);
                await _unitOfWork.SaveAsync();
            }
            //add new user refresh token

            userRefreshToken = new UserRefreshToken()
            {
                IsActive = true,
                RefreshToken = refresh_token,
                UserId = userId
            };


            await _unitOfWork.UserRefreshTokens.AddAsync(userRefreshToken);
            await _unitOfWork.SaveAsync();
        }

        public TokenDto GenerateToken(string userName, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(TokenConstants.JWTKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                            new Claim(ClaimTypes.Name,userName),
                            new Claim("Id",userId.ToString()),
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = GenerateRefreshToken();

            TokenDto tokenDto = new TokenDto()
            {
                Access_Token = tokenHandler.WriteToken(token),
                Refresh_Token = refreshToken
            };

            return tokenDto;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        static byte[] ComputeSha256HashRaw(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                return bytes;
            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(TokenConstants.JWTKey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }


            return principal;
        }

        public async Task<IDataResult<TokenDto>> GenerateRefresh(TokenDto tokenDto)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(tokenDto.Access_Token);
                var username = principal.Identity?.Name;
                var userID = int.Parse(principal.Claims.FirstOrDefault(p => p.Type.ToString() == "Id").Value);


                var user = await _unitOfWork.Users.GetAsync(p => p.Id == userID);

                if (user == null)
                    return new DataResult<TokenDto>("Invalid Attempt!", null, HttpStatusCode.BadRequest);

                var userRefreshToken = await _unitOfWork.UserRefreshTokens
                    .GetAsync(p => p.UserId == user.Id && p.RefreshToken == tokenDto.Refresh_Token
                    && p.IsActive == true);

                if (userRefreshToken == null)
                    return new DataResult<TokenDto>("Invalid Attempt!", null, HttpStatusCode.BadRequest);

                var userLoginDto = new UserLoginDto()
                {
                    UserName = username,
                };

                var newJwtToken = GenerateToken(username, userID);

                await SaveUserRefreshToken(user.Id, newJwtToken.Refresh_Token);

                return new DataResult<TokenDto>("Token Generated", newJwtToken, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<TokenDto>(ex.Message, null, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<UserDto>> GetUser(int UserId)
        {
            try
            {
                User user = await _unitOfWork.Users.GetAsync(p => p.Id == UserId);

                UserDto userDto = new UserDto()
                {
                    Id = user.Id,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Description = user.Description,
                    Mobile = user.Mobile,
                    Username = user.Username,
                    LastName = user.LastName
                };

                return new DataResult<UserDto>(null, userDto, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<UserDto>(ex.Message, null, HttpStatusCode.InternalServerError);

            }
        }

        public async Task<IDataResult<UserDto>> GetUsersDashboardDatas(int userId)
        {
            try
            {
                User user = await _unitOfWork.Users.GetAsync(p => p.Id == userId);

                UserDto userDto = new UserDto()
                {
                    Id = user.Id,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Description = user.Description,
                    Mobile = user.Mobile,
                    Username = user.Username,
                    LastName = user.LastName
                };

                //get users categories
                CategoryGetDto categoryGetDto = new CategoryGetDto()
                {
                    RecordCount = 4,
                    UserId = userId
                };

                var categories=await _categoryService.GetCategoriesLimitedByUserId(categoryGetDto);
                userDto.Categories = categories.Data;

                var tags = await _tagService.GetUsersTag(userId);
                userDto.Tags = tags.Data;

                var posts = await _postService.GetPostCountLimited(userId, 4);
                userDto.Posts = posts.Data;

                var favoritePosts = await _postService.GetFavoritePosts(userId, 4);
                userDto.FavoritePosts = favoritePosts.Data;

                return new DataResult<UserDto>(null, userDto, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<UserDto>(ex.Message, null, HttpStatusCode.InternalServerError);

            }
        }
    }
}

