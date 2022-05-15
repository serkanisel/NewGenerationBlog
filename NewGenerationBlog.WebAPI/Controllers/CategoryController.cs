using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Services.Abstract;

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
        public async Task<IActionResult> GetCategoriesByUser(CategoryGetDto categoryGetDto)
        {
            var Categories = await _categoryService.GetCategoriesLimitedByUserId(categoryGetDto);

            return Ok(Categories);
        }

        [HttpGet("GetByUserId/{userid}")]
        public async Task<IActionResult> GetByUserId(int userid)
        {
            var Categories = await _categoryService.GetAllByNoneDeleted(userid);

            return Ok(Categories);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryAddDto categoryAddDto)
        {
            var result=await _categoryService.Add(categoryAddDto,1);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryService.Update(categoryUpdateDto);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Category = await _categoryService.Get(id);

            return Ok(Category);
        }
    }
}

