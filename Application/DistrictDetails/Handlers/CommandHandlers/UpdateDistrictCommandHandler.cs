using Application.DistrictDetails.Commands.Request;
using Application.DistrictDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.DistrictDetails.Handlers.CommandHandlers
{
    public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommandRequest, UpdateDistrictCommandResponse>
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDistrictCommandHandler(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateDistrictCommandResponse> Handle(UpdateDistrictCommandRequest request, CancellationToken cancellationToken)
        {
            var district = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, district);
            await _repository.UpdateAsync(district);

            return new UpdateDistrictCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}