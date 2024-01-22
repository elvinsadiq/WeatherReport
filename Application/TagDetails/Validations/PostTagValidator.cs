using Application.TagDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TagDetails.Validations
{
    public class PostTagValidator : AbstractValidator<CreateTagCommandRequest>
    {
        public PostTagValidator()
        {
            RuleFor(request => request.TagName)
            .NotEmpty().WithMessage("Etiket adı boş olamaz.")
            .MaximumLength(50).WithMessage("Etiket adı 50 karakterden uzun olamaz.");
        }
    }
}
