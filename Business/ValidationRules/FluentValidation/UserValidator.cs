
using Entity.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegisterDto>
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
