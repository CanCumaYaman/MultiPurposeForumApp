﻿using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class ArticleValidator:AbstractValidator<Article>
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
