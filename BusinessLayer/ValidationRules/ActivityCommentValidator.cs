using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ActivityCommentValidator : AbstractValidator<ActivityComment>
	{
        public ActivityCommentValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Surname).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Email).MinimumLength(11).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Comment).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Comment).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(600).WithMessage("En fazla 600 karakter girişi yapınız");
        }
    }
}
