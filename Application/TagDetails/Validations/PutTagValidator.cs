using Application.TagDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TagDetails.Validations
{
    public class PutTagValidator : AbstractValidator<UpdateTagCommandRequest>
    {
        public PutTagValidator()
        {
            RuleFor(request => request.Id)
            .GreaterThan(0).WithMessage("Geçerli bir etiket kimliği sağlanmalıdır.");

            RuleFor(request => request.TagName)
            .NotEmpty().WithMessage("Etiket adı boş olamaz.")
            .MaximumLength(50).WithMessage("Etiket adı 50 karakterden uzun olamaz.");
        }
    }
}
