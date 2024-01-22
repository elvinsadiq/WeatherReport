using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Queries.Request
{
    public class GetRelatedProvinceQueryRequest : IRequest<List<GetRelatedProvinceQueryResponse>>
    {
        public int CountryId { get; set; }
    }
}
