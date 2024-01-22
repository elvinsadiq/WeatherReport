using Application.ReviewDetails.Queries.Response;

namespace Application.ProductDetails.ReviewDetails.Queries.Response
{
    public class GetProductReviewListResponse
    {
        public int TotalReviewCount { get; set; }
        public List<GetAllReviewQueryResponse> ProductReviews { get; set; }
    }
}
