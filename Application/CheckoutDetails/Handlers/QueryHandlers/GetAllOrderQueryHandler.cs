using Application.CheckoutDetails.Queries.Request;
using Application.CheckoutDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CheckoutDetails.Handlers.QueryHandlers
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var checkouts = _repository.GetAll(x => true);

            if (checkouts != null)
            {
                List<GetAllOrderQueryResponse> response = _mapper.Map<List<GetAllOrderQueryResponse>>(checkouts);
                return response;
            }
            else
            {
                return new List<GetAllOrderQueryResponse>();
            }
        }
    }
}