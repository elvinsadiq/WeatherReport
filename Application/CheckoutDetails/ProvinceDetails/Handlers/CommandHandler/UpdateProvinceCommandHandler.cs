using Application.CheckoutDetails.ProvinceDetails.Commands.Request;
using Application.CheckoutDetails.ProvinceDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Handlers.CommandHandler
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommandRequest, UpdateProvinceCommandResponse>
    {
        private readonly IProvinceRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProvinceCommandHandler(IProvinceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateProvinceCommandResponse> Handle(UpdateProvinceCommandRequest request, CancellationToken cancellationToken)
        {
            var province = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, province);
            await _repository.UpdateAsync(province);

            return new UpdateProvinceCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
