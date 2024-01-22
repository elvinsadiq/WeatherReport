using Application.ApplicationUserDetails.Commands.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Commands.Request
{
    public class SoftDeleteAppUserCommandRequest : IRequest<SoftDeleteAppUserCommandResponse>
    {
        public string UserName { get; set; }
    }
}
