using Application.DistrictDetails.Queries.Request;
using Application.DistrictDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DistrictDetails.Handlers.QueryHandlers
{
    public class GetByIdDistrictQueryHandler : IRequestHandler<GetByIdDistrictQueryRequest, GetByIdDistrictQueryResponse>
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdDistrictQueryHandler(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdDistrictQueryResponse> Handle(GetByIdDistrictQueryRequest request, CancellationToken cancellationToken)
        {
            var district = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (district != null)
            {
                var response = _mapper.Map<GetByIdDistrictQueryResponse>(district);
                return response;
            }

            return new GetByIdDistrictQueryResponse();
        }
    }
}