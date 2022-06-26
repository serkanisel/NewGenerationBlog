using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using NewGenerationBlog.Data.Abstract;
using NewGenerationBlog.Entities.Concrete;
using NewGenerationBlog.Entities.Dtos;
using NewGenerationBlog.Entities.Dtos.RequestDto;
using NewGenerationBlog.Services.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.Concrete;

namespace NewGenerationBlog.Services.Concrete
{
    public class TagManager : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddTag(TagAddDto tagAddDto)
        {
            try
            {
                //check if exists tag
                Tag tag = await _unitOfWork.Tags.GetAsync(p => p.Name == tagAddDto.Name);

                if (tag == null)
                {
                    tag = new Tag();
                    tag.Name = tagAddDto.Name;
                    tag.UserId = tagAddDto.UserId;


                    await _unitOfWork.Tags.AddAsync(tag);
                    await _unitOfWork.SaveAsync();
                }

                TagPost tagPost = await _unitOfWork.TagPosts.GetAsync(p => p.PostId == tagAddDto.PostId && p.TagId == tag.Id);

                if (tagPost == null)
                {
                    tagPost = new TagPost();
                    tagPost.PostId = tagAddDto.PostId;
                    tagPost.TagId = tag.Id;

                    await _unitOfWork.TagPosts.AddAsync(tagPost);
                    await _unitOfWork.SaveAsync();
                }

                return new Result("Tags saved", HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return new Result("An Error Occured", ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeleteTag(TagAddDto tagAddDto)
        {
            try
            {
                Tag tag = await _unitOfWork.Tags.GetAsync(p => p.Name == tagAddDto.Name);

                TagPost tagPost = await _unitOfWork.TagPosts.GetAsync(p => p.TagId == tag.Id && p.PostId == tagAddDto.PostId);

                await _unitOfWork.TagPosts.DeleteAsync(tagPost);
                await _unitOfWork.SaveAsync();

                return new Result("Tag Deleted", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new Result("An Error Occured", ex.Message, HttpStatusCode.InternalServerError);
            }

        }

        public Task<IDataResult<TagDto>> GetTag(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IList<TagDto>>> GetUsersTag(int userId)
        {
            try
            {
                var tags = await _unitOfWork.Tags.GetAllAsync(c => c.UserId == userId);

                if (tags == null && tags.Count() > 0)
                    return new DataResult<IList<TagDto>>("No tags found", null, HttpStatusCode.OK);

                IList<TagDto> tags1 = new List<TagDto>();
                foreach (var item in tags)
                {
                    TagDto tagDto = new TagDto();
                    tagDto.Name = item.Name;
                    tagDto.CreatedDate = item.CreatedDate;
                    tagDto.Id = item.Id;
                    tagDto.UserId = item.UserId;

                    tags1.Add(tagDto);
                }

                return new DataResult<IList<TagDto>>("", tags1, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<TagDto>>("An Error Occured", null, ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}

