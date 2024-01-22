using Domain.Entities;

namespace Application.CheckoutDetails.CountryDetails.Queries.Response
{
    public class GetByIdCountryQueryResponse
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string Ccode { get; set; }
    }
}