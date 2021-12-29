using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Surname).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage("En fazla 1000 karakter girişi yapınız");
        }
    }
}
