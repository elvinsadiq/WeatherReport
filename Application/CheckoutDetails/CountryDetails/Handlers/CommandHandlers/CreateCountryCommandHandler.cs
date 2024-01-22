// CreateCountryCommandHandler.cs
using Application.CheckoutDetails.CountryDetails.Commands.Request;
using Application.CheckoutDetails.CountryDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Handlers.CommandHandlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest, CreateCountryCommandResponse>
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCountryCommandResponse> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(request);

            await _repository.AddAsync(country);
            await _repository.CommitAsync();

            return new CreateCountryCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
