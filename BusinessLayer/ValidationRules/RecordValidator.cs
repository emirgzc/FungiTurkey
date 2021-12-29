using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class RecordValidator : AbstractValidator<Record>
	{
		public RecordValidator()
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

			RuleFor(x => x.Phone).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.Phone).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
			RuleFor(x => x.Phone).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

			RuleFor(x => x.PeopleNumber).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
			RuleFor(x => x.PeopleNumber).GreaterThan(0).WithMessage("Girilen Değer 0' dan Büyük Olmalı.");

		}
	}
}
