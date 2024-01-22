using Application.ContactMessageDetails.Commands.Response;
using MediatR;

namespace Application.ContactMessageDetails.Commands.Request
{
    public class DeleteContactMessageCommandRequest : IRequest<DeleteContactMessageCommandResponse>
    {
        public int Id { get; set; }
    }
}