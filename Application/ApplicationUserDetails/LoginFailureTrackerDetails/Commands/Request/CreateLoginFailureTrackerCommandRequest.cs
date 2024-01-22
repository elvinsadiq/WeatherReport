using Application.LoginFailureTrackerDetails.Commands.Response;
using MediatR;

namespace Application.LoginFailureTrackerDetails.Commands.Request
{
    public class CreateLoginFailureTrackerCommandRequest : IRequest<CreateLoginFailureTrackerCommandResponse>
    {
        public int AppUserId { get; set; }
        public int LoginTryCount { get; set; }
        public bool IsBlocked { get; set; }
    }
}