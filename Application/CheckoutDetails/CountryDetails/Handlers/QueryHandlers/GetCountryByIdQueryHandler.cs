// GetCountryByIdQueryHandler.cs
using Application.CheckoutDetails.CountryDetails.Queries.Request;
using Application.CheckoutDetails.CountryDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CheckoutDetails.CountryDetails.Handlers.QueryHandlers
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetByIdCountryQueryRequest, GetByIdCountryQueryResponse>
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdCountryQueryResponse> Handle(GetByIdCountryQueryRequest request, CancellationToken cancellationToken)
        {
            var country = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (country != null)
            {
                var response = _mapper.Map<GetByIdCountryQueryResponse>(country);
                return response;
            }

            return new GetByIdCountryQueryResponse();
        }
    }
}
