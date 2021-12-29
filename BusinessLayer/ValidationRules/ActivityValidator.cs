using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ActivityValidator : AbstractValidator<Activity>
	{
		public ActivityValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Title).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.Content).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Content).MinimumLength(15).WithMessage("En az 15 karakter girişi yapınız");

			RuleFor(x => x.Director).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Director).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
			RuleFor(x => x.Director).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.StartDate).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.StartDate).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.StartDate).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.FinishDate).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.FinishDate).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.FinishDate).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

			RuleFor(x => x.LastRecordDate).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.LastRecordDate).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.LastRecordDate).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");
		}
	}
}
