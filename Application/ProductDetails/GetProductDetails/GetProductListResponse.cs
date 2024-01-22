using Application.GetProductDetails.Queries.Response;

namespace Application.GetProductDetails
{
    public class GetProductListResponse
    {
        public int TotalProductCount { get; set; }
        public List<GetProductQueryResponse> Products { get; set; }
    }
}