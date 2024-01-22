using Application.ColorDetails.Commands.Request;
using Application.DescriptionDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ColorDetails.Validations
{
    public class PostColorValidator : AbstractValidator<CreateColorCommandRequest>
    {
        public PostColorValidator()
        {
            RuleFor(request => request.ColorHexCode)
            .NotEmpty().WithMessage("Renk kodu boş olamaz.")
            .MaximumLength(50).WithMessage("Renk kodu 50 karakterden uzun olamaz.");
        }
    }
}
