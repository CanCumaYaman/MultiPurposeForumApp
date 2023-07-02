using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(p => p.Topic).NotEmpty().WithMessage("Topic is required.");
            RuleFor(p => p.Body).NotEmpty().WithMessage("Question body is required.");
            RuleFor(p => p.Body).MinimumLength(20).WithMessage("Your question must be more clear.");
        }
    }
}
