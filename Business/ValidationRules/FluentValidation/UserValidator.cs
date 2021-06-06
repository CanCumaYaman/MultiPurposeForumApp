
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("FirstName is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("LastName is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required.");

        }
    }
}
