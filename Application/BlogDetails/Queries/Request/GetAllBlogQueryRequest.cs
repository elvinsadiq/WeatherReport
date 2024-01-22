using Application.BlogDetails.Queries.Response;
using Application.ProductDetails;
using MediatR;

namespace Application.BlogDetails.Queries.Request
{
    public class GetAllBlogQueryRequest : IRequest<List<GetAllBlogQueryResponse>>
    {
        public int Page { get; set; } = 1;
        public ShowMoreDto ShowMore { get; set; }
    }
}