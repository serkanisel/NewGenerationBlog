using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NewGenerationBlog.Entities.Dtos.RequestDto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewGenerationBlog.WebAPI.ModelValidators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(p => p.Username).NotEmpty().MinimumLength(8);
            RuleFor(p => p.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(p => p.LastName).NotEmpty().MinimumLength(3);
        }
    }
}

