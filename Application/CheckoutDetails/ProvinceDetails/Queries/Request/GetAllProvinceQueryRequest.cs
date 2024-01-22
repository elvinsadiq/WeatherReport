using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.CheckoutDetails.ProvinceDetails.Queries.Request
{
    public class GetAllProvinceQueryRequest : IRequest<List<GetAllProvinceQueryResponse>>
    {
    }
}
