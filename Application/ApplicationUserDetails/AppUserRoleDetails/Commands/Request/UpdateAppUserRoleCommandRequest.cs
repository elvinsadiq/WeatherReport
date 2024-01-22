using Application.AppUserRoleDetails.Commands.Response;
using MediatR;

namespace Application.AppUserRoleDetails.Commands.Request
{
    public class UpdateAppUserRoleCommandRequest : IRequest<UpdateAppUserRoleCommandResponse>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}