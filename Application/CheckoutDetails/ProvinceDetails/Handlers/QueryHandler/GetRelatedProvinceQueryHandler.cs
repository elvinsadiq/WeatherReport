using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.CheckoutDetails.ProvinceDetails.Queries.Request;
using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Handlers.QueryHandler
{
    public class GetRelatedProvinceQueryHandler : IRequestHandler<GetRelatedProvinceQueryRequest, List<GetRelatedProvinceQueryResponse>>
    {
        private readonly IProvinceRepository _repository;
        private readonly IMapper _mapper;

        public GetRelatedProvinceQueryHandler(IProvinceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetRelatedProvinceQueryResponse>> Handle(GetRelatedProvinceQueryRequest request, CancellationToken cancellationToken)
        {
            var provinces = _repository.GetAll(p => p.CountryId == request.CountryId);

            var response = _mapper.Map<List<GetRelatedProvinceQueryResponse>>(provinces);
            return response;
        }
    }
}
