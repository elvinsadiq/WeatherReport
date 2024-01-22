using Application.ColorDetails.Queries.Response;
using MediatR;

namespace Application.ColorDetails.Queries.Request
{
    public class GetByIdColorQueryRequest : IRequest<GetByIdColorQueryResponse>
    {
        public int Id { get; set; }
    }
}
