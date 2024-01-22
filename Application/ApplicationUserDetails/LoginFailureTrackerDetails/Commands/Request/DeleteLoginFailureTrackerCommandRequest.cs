using Application.LoginFailureTrackerDetails.Commands.Response;
using MediatR;

namespace Application.LoginFailureTrackerDetails.Commands.Request
{
    public class DeleteLoginFailureTrackerCommandRequest : IRequest<DeleteLoginFailureTrackerCommandResponse>
    {
        public int Id { get; set; }
    }
}