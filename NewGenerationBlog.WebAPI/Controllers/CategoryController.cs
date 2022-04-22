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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Categories = await _categoryService.GetAllByNoneDeleted(id);

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
    }
}

