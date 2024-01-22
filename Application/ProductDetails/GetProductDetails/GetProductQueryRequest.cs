using Application.ProductDetails;
using MediatR;

namespace Application.GetProductDetails.Queries.Request
{
    public class GetProductQueryRequest : IRequest<List<GetProductListResponse>>
    {
        public int Page { get; set; } = 1;
        public string? Prompt { get; set; }
        public ShowMoreDto? ShowMore { get; set; }
        public List<string>? CategoryNames { get; set; }
        public bool? IsNew { get; set; }
        public List<string>? ProductTags { get; set; }
        public List<string>? ProductSizes { get; set; }
        public List<string>? ProductColors { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? OrderBy { get; set; }
    }
}