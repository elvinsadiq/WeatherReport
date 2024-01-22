using Application.LoginFailureTrackerDetails.Queries.Response;
using MediatR;

namespace Application.LoginFailureTrackerDetails.Queries.Request
{
    public class GetByIdLoginFailureTrackerQueryRequest : IRequest<GetByIdLoginFailureTrackerQueryResponse>
    {
        public int Id { get; set; }
    }
}