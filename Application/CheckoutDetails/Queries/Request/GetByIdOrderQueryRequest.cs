using Application.CheckoutDetails.Queries.Response;
using MediatR;

namespace Application.CheckoutDetails.Queries.Request
{
    public class GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
    {
        public int Id { get; set; }
    }
}