using Application.HomeDetails.Commands.Response;
using MediatR;

namespace Application.HomeDetails.Commands.Request
{
    public class DeleteHomeCommandRequest : IRequest<DeleteHomeCommandResponse>
    {
        public int Id { get; set; }
    }
}