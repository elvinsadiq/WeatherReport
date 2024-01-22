using Application.DescriptionDetails.Commands.Request;
using Application.ProductDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DescriptionDetails.Validations
{
    public class PostDescriptionValidator : AbstractValidator<CreateDescriptionCommandRequest>
    {
        public PostDescriptionValidator()
        {
            RuleFor(request => request.Introduction)
                .NotEmpty().WithMessage("Açıklama girişi boş olamaz.");

            RuleFor(request => request.ImageFiles)
                .NotEmpty().WithMessage("En az bir resim dosyası yüklemelisiniz.");
          
        }
    }
}
