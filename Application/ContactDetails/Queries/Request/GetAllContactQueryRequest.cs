using Application.ContactDetails.Queries.Response;
using MediatR;

namespace Application.ContactDetails.Queries.Request
{
    public class GetAllContactQueryRequest : IRequest<List<GetAllContactQueryResponse>>
    {
    }
}