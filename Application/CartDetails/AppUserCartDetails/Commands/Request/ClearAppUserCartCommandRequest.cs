using Application.AppUserCartDetails.Commands.Response;
using MediatR;

namespace Application.AppUserCartDetails.Commands.Request
{
    public class ClearAppUserCartCommandRequest : IRequest<ClearAppUserCartCommandResponse>
    {
        public int AppUserId { get; set; }
    }
}
