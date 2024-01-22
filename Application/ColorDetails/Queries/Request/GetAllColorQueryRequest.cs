using Application.ColorDetails.Queries.Response;
using MediatR;

namespace Application.ColorDetails.Queries.Request
{
    public class GetAllColorQueryRequest : IRequest<List<GetAllColorQueryResponse>>
    {
    }
}
