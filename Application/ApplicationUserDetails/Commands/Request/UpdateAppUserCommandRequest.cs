using Application.ApplicationUserDetails.Commands.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Commands.Request
{
    public class UpdateAppUserCommandRequest : IRequest<UpdateAppUserCommandResponse>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
