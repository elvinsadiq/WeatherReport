using Application.ApplicationUserDetails.Commands.Request;
using Application.ContactMessageDetails.Commands.Response;
using MediatR;

namespace Application.Commands.Request
{
    public class CreateContactMessageCommandRequest: IRequest<CreateContactMessageCommandResponse>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; }
    }
}