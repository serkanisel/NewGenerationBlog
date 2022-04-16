using System;
using System.Collections.Generic;
using AutoMapper;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Entities.Dtos;

namespace NewGenerationBlog.Services.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostAddDto, Post>();
            CreateMap<PostUpdateDto, Post>();

            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<IList<PostDto>, IList<Post>>().ReverseMap();
        }
    }
}
