using Application.LoginFailureTrackerDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.LoginFailureTrackerDetails.Queries.Request
{
    public class GetAllLoginFailureTrackerQueryRequest : IRequest<List<GetAllLoginFailureTrackerQueryResponse>>
    {
    }
}