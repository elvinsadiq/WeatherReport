using Application.ColorDetails.Commands.Response;
using MediatR;

namespace Application.ColorDetails.Commands.Request
{
    public class DeleteColorCommandRequest : IRequest<DeleteColorCommandResponse>
    {
        public int Id { get; set; }
    }
}
