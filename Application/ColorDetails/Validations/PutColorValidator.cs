using Application.ColorDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ColorDetails.Validations
{
    public class PutColorValidator : AbstractValidator<UpdateColorCommandRequest>
    {
        public PutColorValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Geçerli bir renk kimliği belirtmelisiniz.");

            RuleFor(request => request.ColorHexCode)
                .NotEmpty().WithMessage("Renk kodu boş olamaz.")
                .MaximumLength(50).WithMessage("Renk kodu 50 karakterden uzun olamaz.");
        }
    }
}
