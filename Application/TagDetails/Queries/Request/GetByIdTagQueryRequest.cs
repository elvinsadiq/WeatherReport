using Application.TagDetails.Queries.Response;
using MediatR;

namespace Application.TagDetails.Queries.Request
{
    public class GetByIdTagQueryRequest : IRequest<GetByIdTagQueryResponse>
    {
        public int Id { get; set; }
    }
}
