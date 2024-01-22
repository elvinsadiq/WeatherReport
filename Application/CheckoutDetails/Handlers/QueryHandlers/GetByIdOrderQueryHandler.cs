using Application.CheckoutDetails.Queries.Request;
using Application.CheckoutDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CheckoutDetails.Handlers.QueryHandlers
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdOrderQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var checkout = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (checkout != null)
            {
                var response = _mapper.Map<GetByIdOrderQueryResponse>(checkout);
                return response;
            }

            return new GetByIdOrderQueryResponse();
        }
    }
}