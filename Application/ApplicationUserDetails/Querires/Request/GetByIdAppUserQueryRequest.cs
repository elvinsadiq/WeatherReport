using Application.ApplicationUserDetails.Queries.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Queries.Request
{
    public class GetByIdAppUserQueryRequest : IRequest<GetByIdAppUserQueryResponse>
    {
        public int Id { get; set; }
    }
}
