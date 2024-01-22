using Application.DistrictDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.DistrictDetails.Queries.Request
{
    public class GetAllDistrictQueryRequest : IRequest<List<GetAllDistrictQueryResponse>>
    {
    }
}