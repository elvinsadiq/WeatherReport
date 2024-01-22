using Application.BlogDetails.Queries.Response;
using Application.HomeDetails.Queries.Response;
using MediatR;

namespace Application.HomeDetails.Queries.Request
{
    public class GetAllHomeQueryRequest : IRequest<List<GetAllHomeQueryResponse>>
    {
    }
}