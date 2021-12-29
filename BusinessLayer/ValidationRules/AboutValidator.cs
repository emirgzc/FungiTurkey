using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AboutValidator : AbstractValidator<About>
	{
        public AboutValidator()
        {
            RuleFor(x => x.Vision).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Vision).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");

            RuleFor(x => x.Mission).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Mission).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
        }
    }
}
