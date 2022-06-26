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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewGenerationBlog.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategoriesByUser/{count}")]
        public async Task<IDataResult<IList<CategoryDto>>> GetCategoriesByUser(int count)
        {
            CategoryGetDto getDto = new CategoryGetDto()
            {
                RecordCount = count,
                UserId = UserId
            };

            return await _categoryService.GetCategoriesLimitedByUserId(getDto);
        }

        [HttpGet("GetByUserId")]
        public async Task<IDataResult<IList<CategoryDto>>> GetByUserId()
        {
            return await _categoryService.GetAllByNoneDeleted(UserId);
        }

        [HttpPost]
        public async Task<IDataResult<CategoryDto>> Post(CategoryAddDto categoryAddDto)
        {
            return await _categoryService.Add(categoryAddDto,UserId);
        }

        [HttpPut]
        public async Task<IResult> Put(CategoryUpdateDto categoryUpdateDto)
        {
            return await _categoryService.Update(categoryUpdateDto,UserId);
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<CategoryDto>> Get(int id)
        {
            return await _categoryService.Get(id);
        }

        [HttpPost("SoftDelete")]
        public async Task<IResult> SoftDelete(CategoryDeleteDto categoryDeleteDto)
        {
            return await _categoryService.Delete(categoryDeleteDto.Id);
        }
    }
}

