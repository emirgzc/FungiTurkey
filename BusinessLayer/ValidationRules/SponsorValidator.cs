using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SponsorValidator : AbstractValidator<Sponsor>
    {
        public SponsorValidator()
        {
            RuleFor(x => x.SponsorName).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.SponsorName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.SponsorName).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.SponsorWebSite).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.SponsorWebSite).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.SponsorWebSite).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");
        }
    }
}
