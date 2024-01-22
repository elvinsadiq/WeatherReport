using Application.CheckoutDetails.ProvinceDetails.Commands.Request;
using Application.CheckoutDetails.ProvinceDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Handlers.CommandHandler
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommandRequest, CreateProvinceCommandResponse>
    {
        private readonly IProvinceRepository _repository;
        private readonly IMapper _mapper;

        public CreateProvinceCommandHandler(IProvinceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateProvinceCommandResponse> Handle(CreateProvinceCommandRequest request, CancellationToken cancellationToken)
        {
            var province = _mapper.Map<Province>(request);

            await _repository.AddAsync(province);
            await _repository.CommitAsync();

            return new CreateProvinceCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
