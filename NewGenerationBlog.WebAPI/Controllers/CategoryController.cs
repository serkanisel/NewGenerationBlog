using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewGenerationBlog.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("GetCategoriesByUser")]
        public async Task<IDataResult<IList<CategoryDto>>> GetCategoriesByUser(CategoryGetDto categoryGetDto)
        {
            return await _categoryService.GetCategoriesLimitedByUserId(categoryGetDto);
        }

        [HttpGet("GetByUserId/{userid}")]
        public async Task<IDataResult<IList<CategoryDto>>> GetByUserId(int userid)
        {
            return await _categoryService.GetAllByNoneDeleted(userid);
        }

        [HttpPost]
        public async Task<IDataResult<CategoryDto>> Post(CategoryAddDto categoryAddDto)
        {
            return await _categoryService.Add(categoryAddDto,1);
        }

        [HttpPut]
        public async Task<IResult> Put(CategoryUpdateDto categoryUpdateDto)
        {
            return await _categoryService.Update(categoryUpdateDto);
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

