using Application.HomeDetails.Queries.Response;
using MediatR;

namespace Application.HomeDetails.Queries.Request
{
    public class GetByIdHomeQueryRequest : IRequest<GetByIdHomeQueryResponse>
    {
        public int Id { get; set; }
    }
}
