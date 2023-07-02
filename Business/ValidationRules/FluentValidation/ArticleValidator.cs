using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(p => p.Topic).NotEmpty().WithMessage("Topic is required.");
            RuleFor(p => p.Body).NotEmpty().WithMessage("Article body is required.");
            RuleFor(p => p.Body).MinimumLength(40).WithMessage("Your article must bu more clear.");
        }
    }
}
