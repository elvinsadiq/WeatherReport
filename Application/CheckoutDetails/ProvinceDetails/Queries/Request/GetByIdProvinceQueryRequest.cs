using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Queries.Request
{
    public class GetByIdProvinceQueryRequest : IRequest<GetByIdProvinceQueryResponse>
    {
        public int Id { get; set; }
    }
}
