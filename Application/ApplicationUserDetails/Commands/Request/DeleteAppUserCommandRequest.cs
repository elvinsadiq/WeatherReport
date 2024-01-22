using Application.ApplicationUserDetails.Commands.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Commands.Request
{
    public class DeleteAppUserCommandRequest : IRequest<DeleteAppUserCommandResponse>
    {
        public int Id { get; set; }
    }
}
