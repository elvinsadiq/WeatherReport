using Domain.Entities;
using FluentValidation;

namespace Application.FavoriteDetails.Handlers.Validation
{
    public class FavoriteValidator : AbstractValidator<Favorite>
    {
        public FavoriteValidator()
        {
            RuleFor(c => c.User).NotEmpty().NotNull();
            RuleFor(c => c.Product).NotEmpty().NotNull();
        }
    }
}