using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SettingsValidator : AbstractValidator<Settings>
	{
		public SettingsValidator()
		{
			RuleFor(x => x.Address).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Address).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Address).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Phone).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Phone).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Phone).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

			RuleFor(x => x.Email).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Email).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Email).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

			RuleFor(x => x.DirectorName).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.DirectorName).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.DirectorName).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Facebook).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Facebook).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Facebook).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Twitter).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Twitter).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Twitter).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Linkedin).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Linkedin).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Linkedin).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Instagram).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Instagram).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Instagram).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Youtube).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Youtube).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Youtube).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Map).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Map).MinimumLength(15).WithMessage("En az 15 karakter girişi yapınız");
			RuleFor(x => x.Map).MaximumLength(600).WithMessage("En fazla 600 karakter girişi yapınız");

			RuleFor(x => x.CopyrightSite).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.CopyrightSite).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.CopyrightSite).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.RizaMetni).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.RizaMetni).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
			RuleFor(x => x.RizaMetni).MaximumLength(3000).WithMessage("En fazla 3000 karakter girişi yapınız");
		}
	}
}
