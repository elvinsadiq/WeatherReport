using Application.DistrictDetails.Commands.Request;
using Application.DistrictDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DistrictDetails.Handlers.CommandHandlers
{
    public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommandRequest, CreateDistrictCommandResponse>
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;

        public CreateDistrictCommandHandler(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateDistrictCommandResponse> Handle(CreateDistrictCommandRequest request, CancellationToken cancellationToken)
        {
            var district = _mapper.Map<District>(request);

            await _repository.AddAsync(district);
            await _repository.CommitAsync();

            return new CreateDistrictCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}