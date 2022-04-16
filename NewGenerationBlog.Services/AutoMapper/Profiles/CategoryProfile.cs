using System;
using System.Collections.Generic;
using AutoMapper;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Entities.Dtos;

namespace NewGenerationBlog.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<PostDto, Post>();
            CreateMap<Post, PostDto>();
        }
    }
}
