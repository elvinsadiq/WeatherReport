using Application.LoginFailureTrackerDetails.Commands.Request;
using Application.LoginFailureTrackerDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoginFailureTrackerDetails.Handlers.CommandHandlers
{
    public class DeleteLoginFailureTrackerCommandHandler : IRequestHandler<DeleteLoginFailureTrackerCommandRequest, DeleteLoginFailureTrackerCommandResponse>
    {
        private readonly ILoginFailureTrackerRepository _repository;

        public DeleteLoginFailureTrackerCommandHandler(ILoginFailureTrackerRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteLoginFailureTrackerCommandResponse> Handle(DeleteLoginFailureTrackerCommandRequest request, CancellationToken cancellationToken)
        {
            var loginfailuretracker = await _repository.GetAsync(x => x.Id == request.Id);

            if (loginfailuretracker == null)
            {
                return new DeleteLoginFailureTrackerCommandResponse { IsSuccess = false };
            }

            _repository.Remove(loginfailuretracker);
            await _repository.CommitAsync();

            return new DeleteLoginFailureTrackerCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}