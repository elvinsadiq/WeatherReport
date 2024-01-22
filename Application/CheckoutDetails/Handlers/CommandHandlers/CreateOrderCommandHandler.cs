using Application.CheckoutDetails.Commands.Request;
using Application.CheckoutDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CheckoutDetails.Handlers.CommandHandlers
{
    public class CreateCheckoutCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public CreateCheckoutCommandHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var checkout = _mapper.Map<Order>(request);

            await _repository.AddAsync(checkout);
            await _repository.CommitAsync();

            return new CreateOrderCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}