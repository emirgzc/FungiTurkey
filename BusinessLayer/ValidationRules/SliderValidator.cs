using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SliderValidator : AbstractValidator<Slider>
    {
        public SliderValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Content).MaximumLength(2000).WithMessage("En fazla 2000 karakter girişi yapınız");

            RuleFor(x => x.ButonHref).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.ButonHref).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.ButonHref).MaximumLength(20).WithMessage("En fazla 20 karakter girişi yapınız");

            RuleFor(x => x.ButonTitle).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.ButonTitle).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.ButonTitle).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");
        }
    }
}
