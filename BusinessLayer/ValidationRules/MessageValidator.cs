using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class MessageValidator : AbstractValidator<Message>
	{
        public MessageValidator()
        {
            RuleFor(x => x.SenderMail).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.SenderMail).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.ReceiverMail).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("En az 5 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.MessageCont).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.MessageCont).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.MessageCont).MaximumLength(750).WithMessage("En fazla 750 karakter girişi yapınız");
        }
    }
}
