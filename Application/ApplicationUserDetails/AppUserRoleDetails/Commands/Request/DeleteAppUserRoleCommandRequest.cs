using Application.AppUserRoleDetails.Commands.Response;
using MediatR;

namespace Application.AppUserRoleDetails.Commands.Request
{
    public class DeleteAppUserRoleCommandRequest : IRequest<DeleteAppUserRoleCommandResponse>
    {
        public int Id { get; set; }
    }
}