using Application.CheckoutDetails.ProvinceDetails.Queries.Request;
using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckoutDetails.ProvinceDetails.Handlers.QueryHandler
{
    public class GetAllProvinceQueryHandler : IRequestHandler<GetAllProvinceQueryRequest, List<GetAllProvinceQueryResponse>>
    {
        private readonly IProvinceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProvinceQueryHandler(IProvinceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProvinceQueryResponse>> Handle(GetAllProvinceQueryRequest request, CancellationToken cancellationToken)
        {
            var provinces = _repository.GetAll(x => true).Include(p => p.Country).ToList();

            if (provinces != null)
            {
                var response = _mapper.Map<List<GetAllProvinceQueryResponse>>(provinces);
                return response;
            }
            else
            {
                return new List<GetAllProvinceQueryResponse>();
            }
        }
    }
}
