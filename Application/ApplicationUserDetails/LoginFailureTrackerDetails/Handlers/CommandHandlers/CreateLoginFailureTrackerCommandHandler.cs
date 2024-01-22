using Application.LoginFailureTrackerDetails.Commands.Request;
using Application.LoginFailureTrackerDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoginFailureTrackerDetails.Handlers.CommandHandlers
{
    public class CreateLoginFailureTrackerCommandHandler : IRequestHandler<CreateLoginFailureTrackerCommandRequest, CreateLoginFailureTrackerCommandResponse>
    {
        private readonly ILoginFailureTrackerRepository _repository;
        private readonly IMapper _mapper;

        public CreateLoginFailureTrackerCommandHandler(ILoginFailureTrackerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateLoginFailureTrackerCommandResponse> Handle(CreateLoginFailureTrackerCommandRequest request, CancellationToken cancellationToken)
        {
            var loginfailuretracker = _mapper.Map<LoginFailureTracker>(request);

            await _repository.AddAsync(loginfailuretracker);
            await _repository.CommitAsync();

            return new CreateLoginFailureTrackerCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}