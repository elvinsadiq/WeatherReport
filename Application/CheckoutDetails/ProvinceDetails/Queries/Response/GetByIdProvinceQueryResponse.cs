using Domain.Entities;

namespace Application.CheckoutDetails.ProvinceDetails.Queries.Response
{
    public class GetByIdProvinceQueryResponse
    {
        public int Id { get; set; }
        public CountryResponse Country { get; set; }
        public string ProvinceName { get; set; }
    }
}
