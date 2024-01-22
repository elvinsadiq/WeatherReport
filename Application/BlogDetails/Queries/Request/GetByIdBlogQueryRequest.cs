using Application.BlogDetails.Queries.Response;
using MediatR;

namespace Application.BlogDetails.Queries.Request
{
    public class GetByIdBlogQueryRequest : IRequest<GetByIdBlogQueryResponse>
    {
        public int Id { get; set; }
    }
}
