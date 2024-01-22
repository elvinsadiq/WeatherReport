using Domain.Entities;

namespace Application.CheckoutDetails.ProvinceDetails.Queries.Response
{
    public class GetAllProvinceQueryResponse
    {
        public int Id { get; set; }
        public CountryResponse Country { get; set; }
        public string ProvinceName { get; set; }
    }
    public class CountryResponse
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
