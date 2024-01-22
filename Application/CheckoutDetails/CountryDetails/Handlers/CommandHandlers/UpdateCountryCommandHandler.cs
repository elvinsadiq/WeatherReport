using Application.CheckoutDetails.CountryDetails.Commands.Request;
using Application.CheckoutDetails.CountryDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Handlers.CommandHandlers
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommandRequest, UpdateCountryCommandResponse>
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCountryCommandResponse> Handle(UpdateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, country);
            await _repository.UpdateAsync(country);

            return new UpdateCountryCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
