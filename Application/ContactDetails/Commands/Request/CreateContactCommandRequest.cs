using Application.ContactDetails.Commands.Response;
using MediatR;

namespace Application.ContactDetails.Commands.Request
{
    public class CreateContactCommandRequest : IRequest<CreateContactCommandResponse>
    {
        public string Mobile { get; set; }
        public string Hotline { get; set; }
        public string Address { get; set; }
        public string WeekdayWorkingTime { get; set; }
        public string WeekendWorkingTime { get; set; }
    }
}