using Application.LoginFailureTrackerDetails.Commands.Response;
using MediatR;

namespace Application.LoginFailureTrackerDetails.Commands.Request
{
    public class UpdateLoginFailureTrackerCommandRequest : IRequest<UpdateLoginFailureTrackerCommandResponse>
    {
        public int Id { get; set; }
        public int LoginTryCount { get; set; }
        public bool IsBlocked { get; set; }
    }
}