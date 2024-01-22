using Application.AppUserRoleDetails.Queries.Response;
using MediatR;

namespace Application.AppUserRoleDetails.Queries.Request
{
    public class GetByIdAppUserRoleQueryRequest : IRequest<GetByIdAppUserRoleQueryResponse>
    {
        public int Id { get; set; }
    }
}