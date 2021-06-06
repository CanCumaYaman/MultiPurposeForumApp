using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator:AbstractValidator<QuestionComment>
    {
        public CommentValidator()
        {
            RuleFor(p => p.Comment).NotEmpty().WithMessage("Title is required.");
            
            
        }
    }
}
