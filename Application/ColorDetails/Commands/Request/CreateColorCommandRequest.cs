using Application.ColorDetails.Commands.Response;
using MediatR;

namespace Application.ColorDetails.Commands.Request
{
    public class CreateColorCommandRequest : IRequest<CreateColorCommandResponse>
    {
        public string ColorHexCode { get; set; }
    }
}
