using Application.ApplicationUserDetails.Queries.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Queries.Request
{
    public class GetAllAppUserQueryRequest : IRequest<List<GetAllAppUserQueryResponse>>
    {
    }
}
