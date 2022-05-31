using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using NewGenerationBlog.Entities.Dtos;

namespace NewGenerationBlog.WebAPI.ModelValidators
{
	public class CategoryValidator : AbstractValidator<CategoryAddDto>
	{
		public CategoryValidator()
		{
			RuleFor(t => t.Name).NotEmpty().Length(3,70);
		}
	}
}

