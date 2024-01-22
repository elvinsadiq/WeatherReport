using Application.ApplicationUserDetails.Queries.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Queries.Request
{
    public class GetByIdAdminUserQueryRequest : IRequest<GetByIdAdminUserQueryResponse>
    {
        public int Id { get; set; }
    }
}
