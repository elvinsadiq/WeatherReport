using Application.ProductDetails;
using Application.ProductDetails.ReviewDetails.Queries.Response;
using Application.ReviewDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.ReviewDetails.Queries.Request
{
    public class GetAllReviewQueryRequest : IRequest<GetProductReviewListResponse>
    {
        public int ProductId { get; set; }
        public int Page { get; set; } = 1;
        public ShowMoreDto ShowMore { get; set; }
    }
}