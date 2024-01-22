using Application.ColorDetails.Commands.Response;
using MediatR;

namespace Application.ColorDetails.Commands.Request
{
    public class UpdateColorCommandRequest : IRequest<UpdateColorCommandResponse>
    {
        public int Id { get; set; }
        public string ColorHexCode { get; set; }
    }
}
