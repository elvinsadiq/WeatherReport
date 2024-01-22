using Application.ProductDetails.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.Validations
{
    public class PutProductValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public PutProductValidator()
        {
            RuleFor(request => request.Title)
                .MaximumLength(100).WithMessage("Başlık 100 karakterden uzun olamaz.");

            RuleFor(request => request.SubTitle)
                .MaximumLength(200).WithMessage("Alt başlık 100 karakterden uzun olamaz.");

            RuleFor(request => request.Introduction)
                .MaximumLength(1000);

            RuleFor(request => request.SalePrice)
                .GreaterThan(0).WithMessage("Satış fiyatı 0'dan büyük olmalıdır.");

            RuleFor(request => request.CostPrice)
                .GreaterThan(0).WithMessage("Maliyet fiyatı 0'dan büyük olmalıdır.");

            RuleFor(request => request.DiscountPercent)
                .GreaterThanOrEqualTo(0).WithMessage("İndirim yüzdesi 0 veya daha büyük olmalıdır.");

            RuleFor(request => request.Sku)
                .MaximumLength(50).WithMessage("SKU 50 karakterden uzun olamaz.");

            RuleFor(request => request.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori kimliği sağlanmalıdır.");

        }
    }
}
