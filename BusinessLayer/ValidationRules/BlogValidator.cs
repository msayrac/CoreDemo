﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Title Boş Bırakılamaz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Bırakılamaz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görseli Boş Bırakılamaz.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden az veri girişi yapınız.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden fazla veri girişi yapınız.");
        }
    }
}
