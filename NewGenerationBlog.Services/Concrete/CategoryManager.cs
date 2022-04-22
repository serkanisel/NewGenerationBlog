﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;
using NewGenerationBlog.Shared.Utilities.Results.Concrete;
using System.Collections.Generic;

namespace NewGenerationBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, int createdById)
        {
            try
            {
                Category category = new Category();
                category.Name = categoryAddDto.Name;
                category.Description = categoryAddDto.Description;
                category.UserId = createdById;

                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveAsync();

                CategoryDto cDto = new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    CreatedDate = category.CreatedDate,
                };
               
                return new DataResult<CategoryDto>(ResultStatus.Success, "Category added succesfully" ,cDto);
            }
            catch (Exception ex)
            {
                return new DataResult<CategoryDto>(ResultStatus.Error,"An error occured",null,ex.Message);
            }
        }

        public async Task<IResult> Delete(int categoryID)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryID);

            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{category.Name} is deleted");
            }

            return new Result(ResultStatus.Error, "No Such Category Found");
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryID)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryID, c => c.Posts);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, categoryDto);
            }

            return new DataResult<CategoryDto>(ResultStatus.Error, "No category found", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Posts);

            var categoryDtoList = _mapper.Map<IList<CategoryDto>>(categories);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categoryDtoList
                });
            }

            return new DataResult<CategoryListDto>(ResultStatus.Error, "No Category Found", null);
        }

        public async Task<IDataResult<IList<CategoryDto>>> GetAllByNoneDeleted(int userId)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false && c.UserId==userId);

            if (categories.Count > -1)
            {
                IList<CategoryDto> result = new List<CategoryDto>();
                foreach (var item in categories)
                {
                    CategoryDto categoryDto = new CategoryDto();
                    categoryDto.Id = item.Id;
                    categoryDto.Name = item.Name;
                    categoryDto.Description = item.Description;
                    categoryDto.PostCount = await _unitOfWork.Posts.CountAsync(p => p.CategoryId == item.Id);
                    categoryDto.CreatedDate = item.CreatedDate;
                    categoryDto.ModifiedDate = item.ModifiedDate;

                    result.Add(categoryDto);
                }

                return new DataResult<IList<CategoryDto>>(ResultStatus.Success, result);
            }

            return new DataResult<IList<CategoryDto>>(ResultStatus.Error, "No Category Found", null);
        }

        public async Task<IResult> HardDelete(int categoryID)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryID);

            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{category.Name} is deleted from Database");
            }

            return new Result(ResultStatus.Error, "No Such Category Found");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);

                if (category != null)
                {
                    category.Name = categoryUpdateDto.Name;
                    category.Description = categoryUpdateDto.Description;
                    category.ModifiedDate = DateTime.Now;

                    await _unitOfWork.Categories.UpdateAsync(category);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, "Category Updated", null);
                };

                return new Result(ResultStatus.Success, "No Such Category Found", null);
            }
            catch (Exception ex)
            {
                return new Result(ResultStatus.Error, "An error occured", ex.Message);
            }
            
        }
    }
}
