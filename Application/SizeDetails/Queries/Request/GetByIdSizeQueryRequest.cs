using Application.SizeDetails.Queries.Response;
using MediatR;

namespace Application.SizeDetails.Queries.Request
{
    public class GetByIdSizeQueryRequest : IRequest<GetByIdSizeQueryResponse>
    {
        public int Id { get; set; }
    }
}
