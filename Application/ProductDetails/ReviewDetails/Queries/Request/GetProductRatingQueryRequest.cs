using Application.ReviewDetails.Queries.Response;
using MediatR;

namespace Application.ReviewDetails.Queries.Request
{
    public class GetProductRatingQueryRequest : IRequest<GetProductRatingQueryResponse>
    {
        public int ProductId { get; set; }
    }
}