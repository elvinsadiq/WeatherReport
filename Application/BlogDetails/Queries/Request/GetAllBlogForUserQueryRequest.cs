using Application.BlogDetails.Queries.Response;
using Application.ProductDetails;
using MediatR;

namespace Application.BlogDetails.Queries.Request
{
    public class GetAllBlogForUserQueryRequest : IRequest<List<GetBlogListResponse>>
    {
        public int Page { get; set; } = 1;
        public ShowMoreDto ShowMore { get; set; }
        public string? Prompt { get; set; }
        public int? CategoryId { get; set; }
    }
}