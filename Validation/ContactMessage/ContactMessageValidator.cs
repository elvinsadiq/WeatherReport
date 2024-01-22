using Application.Commands.Request;
using FluentValidation;

namespace Validation.ContactMessage
{
    public class ContactMessageValidator : AbstractValidator<CreateContactMessageCommandRequest>
    {
        public ContactMessageValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Email).NotEmpty().NotNull();
            RuleFor(c => c.Message).NotEmpty().NotNull();
        }
    }
}