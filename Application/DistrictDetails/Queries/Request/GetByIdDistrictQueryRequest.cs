using Application.DistrictDetails.Queries.Response;
using MediatR;

namespace Application.DistrictDetails.Queries.Request
{
    public class GetByIdDistrictQueryRequest : IRequest<GetByIdDistrictQueryResponse>
    {
        public int Id { get; set; }
    }
}