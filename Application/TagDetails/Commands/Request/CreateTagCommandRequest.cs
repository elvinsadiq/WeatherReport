using Application.TagDetails.Commands.Response;
using MediatR;

namespace Application.TagDetails.Commands.Request
{
    public class CreateTagCommandRequest : IRequest<CreateTagCommandResponse>
    {
        public string TagName { get; set; }
    }
}
