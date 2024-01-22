using Application.ContactDetails.Commands.Response;
using MediatR;

namespace Application.ContactDetails.Commands.Request
{
    public class DeleteContactCommandRequest : IRequest<DeleteContactCommandResponse>
    {
        public int Id { get; set; }
    }
}