using Application.AppUserRoleDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.AppUserRoleDetails.Queries.Request
{
    public class GetAllAppUserRoleQueryRequest : IRequest<List<GetAllAppUserRoleQueryResponse>>
    {
    }
}