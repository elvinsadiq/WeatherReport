using Application.SizeDetails.Commands.Response;
using MediatR;

namespace Application.SizeDetails.Commands.Request
{
    public class CreateSizeCommandRequest : IRequest<CreateSizeCommandResponse>
    {
        public string SizeName { get; set; }
    }
}
