// GetAllCountriesQueryHandler.cs
using Application.CheckoutDetails.CountryDetails.Queries.Request;
using Application.CheckoutDetails.CountryDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Handlers.QueryHandlers
{
    public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQueryRequest, List<GetAllCountryQueryResponse>>
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCountryQueryHandler(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCountryQueryResponse>> Handle(GetAllCountryQueryRequest request, CancellationToken cancellationToken)
        {
            var countries = _repository.GetAll(x => true);

            if (countries != null)
            {
                var response = _mapper.Map<List<GetAllCountryQueryResponse>>(countries);
                return response;
            }
            else
            {
                return new List<GetAllCountryQueryResponse>();
            }
        }
    }
}
