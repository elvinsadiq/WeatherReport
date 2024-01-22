using Application.DescriptionDetails.Commands.Response;
using MediatR;

namespace Application.DescriptionDetails.Commands.Request
{
    public class DeleteDescriptionCommandRequest : IRequest<DeleteDescriptionCommandResponse>
    {
        public int Id { get; set; }
    }
}
