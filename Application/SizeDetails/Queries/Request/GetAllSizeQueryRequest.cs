using Application.SizeDetails.Queries.Response;
using MediatR;

namespace Application.SizeDetails.Queries.Request
{
    public class GetAllSizeQueryRequest : IRequest<List<GetAllSizeQueryResponse>>
    {
        public int Page { get; set; } = 1;
    }
}
