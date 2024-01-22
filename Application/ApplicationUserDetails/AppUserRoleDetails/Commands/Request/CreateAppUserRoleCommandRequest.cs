using Application.AppUserRoleDetails.Commands.Response;
using MediatR;

namespace Application.AppUserRoleDetails.Commands.Request
{
    public class CreateAppUserRoleCommandRequest : IRequest<CreateAppUserRoleCommandResponse>
    {
        public string RoleName { get; set; }
    }
}