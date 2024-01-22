using Application.ContactMessageDetails.Queries.Response;
using MediatR;

namespace Application.ContactMessageDetails.Queries.Request
{
    public class GetByIdContactMessageQueryRequest : IRequest<GetByIdContactMessageQueryResponse>
    {
        public int Id { get; set; }
    }
}