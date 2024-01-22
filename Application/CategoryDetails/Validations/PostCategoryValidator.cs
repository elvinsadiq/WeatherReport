using Application.CategoryDetails.Commands.Request;
using Application.ColorDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryDetails.Validations
{
    public class PostCategoryValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public PostCategoryValidator()
        {
            RuleFor(request => request.CategoryName)
            .NotEmpty().WithMessage("Kategori adı boş olamaz.")
            .MaximumLength(50).WithMessage("Kategori adı 50 karakterden uzun olamaz.");
        }
    }
}
