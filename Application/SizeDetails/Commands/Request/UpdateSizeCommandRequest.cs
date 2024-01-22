using Application.SizeDetails.Commands.Response;
using MediatR;

namespace Application.SizeDetails.Commands.Request
{
    public class UpdateSizeCommandRequest : IRequest<UpdateSizeCommandResponse>
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
    }
}
