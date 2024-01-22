using Application.Commands.Request;
using FluentValidation;

namespace Application.ContactMessageDetails.Handlers.Validation
{
    public class ContactMessageValidator : AbstractValidator<CreateContactMessageCommandRequest>
    {
        public ContactMessageValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(c => c.Message).NotEmpty().NotNull();
        }
    }
}