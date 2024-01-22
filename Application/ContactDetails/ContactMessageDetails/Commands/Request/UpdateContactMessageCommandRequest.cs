using Application.ContactMessageDetails.Commands.Response;
using MediatR;

namespace Application.ContactMessageDetails.Commands.Request
{
    public class UpdateContactMessageCommandRequest : IRequest<UpdateContactMessageCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; }

    }
}