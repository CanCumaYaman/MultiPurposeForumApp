using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<QuestionComment>
    {
        public CommentValidator()
        {
            RuleFor(p => p.Comment).NotEmpty().WithMessage("Title is required.");
        }
    }
}
