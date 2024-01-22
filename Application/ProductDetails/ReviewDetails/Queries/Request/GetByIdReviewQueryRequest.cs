using Application.ReviewDetails.Queries.Response;
using MediatR;

namespace Application.ReviewDetails.Queries.Request
{
    public class GetByIdReviewQueryRequest : IRequest<GetByIdReviewQueryResponse>
    {
        public int Id { get; set; }
    }
}