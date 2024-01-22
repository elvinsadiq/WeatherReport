using Application.SizeDetails.Commands.Response;
using MediatR;

namespace Application.SizeDetails.Commands.Request
{
    public class DeleteSizeCommandRequest : IRequest<DeleteSizeCommandResponse>
    {
        public int Id { get; set; }
    }
}
