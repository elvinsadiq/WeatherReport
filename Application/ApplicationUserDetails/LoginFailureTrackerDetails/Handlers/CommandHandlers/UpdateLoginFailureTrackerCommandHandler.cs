using Application.LoginFailureTrackerDetails.Commands.Request;
using Application.LoginFailureTrackerDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.LoginFailureTrackerDetails.Handlers.CommandHandlers
{
    public class UpdateLoginFailureTrackerCommandHandler : IRequestHandler<UpdateLoginFailureTrackerCommandRequest, UpdateLoginFailureTrackerCommandResponse>
    {
        private readonly ILoginFailureTrackerRepository _repository;
        private readonly IMapper _mapper;

        public UpdateLoginFailureTrackerCommandHandler(ILoginFailureTrackerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateLoginFailureTrackerCommandResponse> Handle(UpdateLoginFailureTrackerCommandRequest request, CancellationToken cancellationToken)
        {
            var loginfailuretracker = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, loginfailuretracker);
            await _repository.UpdateAsync(loginfailuretracker);

            return new UpdateLoginFailureTrackerCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}