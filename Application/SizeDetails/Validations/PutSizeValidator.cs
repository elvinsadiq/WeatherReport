using Application.SizeDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SizeDetails.Validations
{
    public class PutSizeValidator : AbstractValidator<UpdateSizeCommandRequest>
    {
        public PutSizeValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Geçerli bir boyut kimliği sağlanmalıdır.");

            RuleFor(request => request.SizeName)
                .NotEmpty().WithMessage("Boyut adı boş olamaz.")
                .MaximumLength(50).WithMessage("Boyut adı 50 karakterden uzun olamaz.");

        }
    }
}
