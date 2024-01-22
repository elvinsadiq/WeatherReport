namespace Application.CheckoutDetails.CountryDetails.Queries.Response
{
    public class GetAllCountryQueryResponse
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string Ccode { get; set; }
        public List<ProvinceResponse> Provinces { get; set; }

    }

    public class ProvinceResponse
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
    }
}