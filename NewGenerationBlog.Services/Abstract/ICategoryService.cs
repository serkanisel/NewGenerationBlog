using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;

namespace NewGenerationBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryID);
        Task<IDataResult<CategoryListDto>>  GetAll();
        Task<IDataResult<IList<CategoryDto>>> GetAllByNoneDeleted(int userId);
        Task<IDataResult<IList<CategoryDto>>> GetCategoriesLimitedByUserId(CategoryGetDto categoryGetDto);
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto,int createdById);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto,int createdById);
        Task<IResult> Delete(int categoryID);
        Task<IResult> HardDelete(int categoryID);
        Task<IDataResult<IList<CategoryDto>>> Search(string term,int userId);
    }
}
