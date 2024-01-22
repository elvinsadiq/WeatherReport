using Application.DescriptionDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DescriptionDetails.Validations
{
    public class PutDescriptionValidator : AbstractValidator<UpdateDescriptionCommandRequest>
    {
        public PutDescriptionValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Geçerli bir açıklama kimliği belirtmelisiniz.");


            RuleFor(request => request.Introduction)
                .NotEmpty().WithMessage("Açıklama girişi boş olamaz.");
        }
    }
}
