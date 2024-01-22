using Application.AppUserRoleDetails.Commands.Request;
using Application.AppUserRoleDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.AppUserRoleDetails.Handlers.CommandHandlers
{
    public class UpdateAppUserRoleCommandHandler : IRequestHandler<UpdateAppUserRoleCommandRequest, UpdateAppUserRoleCommandResponse>
    {
        private readonly IAppUserRoleRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAppUserRoleCommandHandler(IAppUserRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAppUserRoleCommandResponse> Handle(UpdateAppUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var appuserrole = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, appuserrole);
            await _repository.UpdateAsync(appuserrole);

            return new UpdateAppUserRoleCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}