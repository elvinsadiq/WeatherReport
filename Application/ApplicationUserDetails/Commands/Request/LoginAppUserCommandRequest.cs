using Application.ApplicationUserDetails.Commands.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Commands.Request
{
    public class LoginAppUserCommandRequest : IRequest<LoginAppUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

