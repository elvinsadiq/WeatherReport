using Application.TagDetails.Queries.Response;
using MediatR;

namespace Application.TagDetails.Queries.Request
{
    public class GetAllTagQueryRequest : IRequest<List<GetAllTagQueryResponse>>
    {
    }
}
