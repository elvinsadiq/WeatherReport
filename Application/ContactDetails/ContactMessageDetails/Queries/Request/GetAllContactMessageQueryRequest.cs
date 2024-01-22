using Application.ContactMessageDetails.Queries.Response;
using MediatR;

namespace Application.ContactMessageDetails.Queries.Request
{
    public class GetAllContactMessageQueryRequest : IRequest<List<GetAllContactMessageQueryResponse>>
    {
    }
}