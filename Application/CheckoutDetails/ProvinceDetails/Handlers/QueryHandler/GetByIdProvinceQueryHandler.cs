using Application.CheckoutDetails.ProvinceDetails.Queries.Request;
using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Handlers.QueryHandler
{
    public class GetByIdProvinceQueryHandler : IRequestHandler<GetByIdProvinceQueryRequest, GetByIdProvinceQueryResponse>
    {
        private readonly IProvinceRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdProvinceQueryHandler(IProvinceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdProvinceQueryResponse> Handle(GetByIdProvinceQueryRequest request, CancellationToken cancellationToken)
        {
            var province = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id, "Country");

            if (province != null)
            {
                var response = _mapper.Map<GetByIdProvinceQueryResponse>(province);
                return response;
            }

            return new GetByIdProvinceQueryResponse();
        }
    }
}
