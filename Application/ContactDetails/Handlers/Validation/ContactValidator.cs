using Application.ContactDetails.Commands.Request;
using FluentValidation;

namespace Application.ContactDetails.Handlers.Validation
{
    public class ContactValidator : AbstractValidator<CreateContactCommandRequest>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.Mobile).NotNull().NotEmpty();
            RuleFor(x => x.WeekdayWorkingTime).NotNull().NotEmpty();
            RuleFor(x => x.WeekendWorkingTime).NotNull().NotEmpty();
        }
    }
}