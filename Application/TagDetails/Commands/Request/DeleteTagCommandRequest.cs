using Application.TagDetails.Commands.Response;
using MediatR;

namespace Application.TagDetails.Commands.Request
{
    public class DeleteTagCommandRequest : IRequest<DeleteTagCommandResponse>
    {
        public int Id { get; set; }
    }
}
