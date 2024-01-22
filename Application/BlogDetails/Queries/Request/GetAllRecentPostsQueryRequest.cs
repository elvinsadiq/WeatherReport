using Application.BlogDetails.Queries.Response;
using MediatR;

namespace Application.BlogDetails.Queries.Request
{
    public class GetAllRecentPostsQueryRequest : IRequest<List<GetAllRecentPostsQueryResponse>>
    {
    }
}