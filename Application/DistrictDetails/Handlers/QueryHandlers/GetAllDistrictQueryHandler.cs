using Application.DistrictDetails.Queries.Request;
using Application.DistrictDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DistrictDetails.Handlers.QueryHandlers
{
    public class GetAllDistrictQueryHandler : IRequestHandler<GetAllDistrictQueryRequest, List<GetAllDistrictQueryResponse>>
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDistrictQueryHandler(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllDistrictQueryResponse>> Handle(GetAllDistrictQueryRequest request, CancellationToken cancellationToken)
        {
            var districts = _repository.GetAll(x => true);

            if (districts != null)
            {
                List<GetAllDistrictQueryResponse> response = _mapper.Map<List<GetAllDistrictQueryResponse>>(districts);
                return response;
            }
            
            return new List<GetAllDistrictQueryResponse>();
            
        }
    }
}