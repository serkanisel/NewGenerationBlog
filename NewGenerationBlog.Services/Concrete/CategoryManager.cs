using System;
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
using System.Linq;
using System.Net;

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
               
                return new DataResult<CategoryDto>( "Category added succesfully" ,cDto);
            }
            catch (Exception ex)
            {
                return new DataResult<CategoryDto>("An error occured",null,ex.Message,HttpStatusCode.InternalServerError);
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

                return new Result( $"{category.Name} is deleted");
            }

            return new Result("No Such Category Found",HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryID)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryID , c => c.Posts.Where(p => p.IsDeleted==false));
            CategoryDto categoryDto = new CategoryDto();

            if (category != null)
            {
                categoryDto.CreatedById = category.CreatedById;
                categoryDto.CreatedDate = category.CreatedDate;
                categoryDto.Description = category.Description;
                categoryDto.Id = category.Id;
                categoryDto.ModifiedDate = category.ModifiedDate;
                categoryDto.Name = category.Name;

                categoryDto.Posts = new List<PostDto>();
                foreach (var item in category.Posts)
                {
                        PostDto pstDto = new PostDto();
                        pstDto.Content = item.Content;
                        pstDto.CreatedDate = item.CreatedDate;
                        pstDto.Date = item.Date;
                        pstDto.Id = item.Id;
                        pstDto.ModifiedDate = item.ModifiedDate;
                        pstDto.SeoAuthor = item.SeoAuthor;
                        pstDto.SeoDecription = item.SeoDecription;
                        pstDto.SeoTags = item.SeoTags;
                        pstDto.Thumbnail = item.Thumbnail;
                        pstDto.Title = item.Title;
                        pstDto.ViewsCount = item.ViewsCount;
                        pstDto.ContentText = item.ContentText;

                        categoryDto.Posts.Add(pstDto);
                }
                categoryDto.PostCount = category.Posts.Count();

                return new DataResult<CategoryDto>( categoryDto);
            }

            return new DataResult<CategoryDto>( "No category found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null,0, c => c.Posts);

            var categoryDtoList = _mapper.Map<IList<CategoryDto>>(categories);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>( new CategoryListDto
                {
                    Categories = categoryDtoList
                });
            }

            return new DataResult<CategoryListDto>("No Category Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<IList<CategoryDto>>> GetAllByNoneDeleted(int userId)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false && c.UserId==userId);

            if (categories.Count > -1)
            {
                
                IList<CategoryDto> result = new List<CategoryDto>();
                foreach (var item in categories.OrderByDescending(p => p.CreatedDate))
                {
                    CategoryDto categoryDto = new CategoryDto();
                    categoryDto.Id = item.Id;
                    categoryDto.Name = item.Name;
                    categoryDto.Description = item.Description;
                    categoryDto.PostCount = await _unitOfWork.Posts.CountAsync(p => p.CategoryId == item.Id && p.IsDeleted==false);
                    categoryDto.CreatedDate = item.CreatedDate;
                    categoryDto.ModifiedDate = item.ModifiedDate;

                    result.Add(categoryDto);
                }

                
                return new DataResult<IList<CategoryDto>>( result);
            }

            return new DataResult<IList<CategoryDto>>("No Category Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IDataResult<IList<CategoryDto>>> GetCategoriesLimitedByUserId(CategoryGetDto categoryGetDto)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false && c.UserId == categoryGetDto.UserId ,categoryGetDto.RecordCount);

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

                return new DataResult<IList<CategoryDto>>( result);
            }

            return new DataResult<IList<CategoryDto>>("No Category Found", null,HttpStatusCode.BadRequest);
        }

        public async Task<IResult> HardDelete(int categoryID)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryID);

            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result( $"{category.Name} is deleted from Database");
            }

            return new Result( "No Such Category Found",HttpStatusCode.BadRequest);
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

                    return new Result( "Category Updated", null);
                };

                return new Result( "No Such Category Found", null,HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new Result("An error occured", ex.Message,HttpStatusCode.InternalServerError);
            }
            
        }
    }
}
