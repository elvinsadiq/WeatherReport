using Application.CheckoutDetails.CountryDetails.Queries.Response;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Queries.Request
{
    public class GetByIdCountryQueryRequest : IRequest<GetByIdCountryQueryResponse>
    {
        public int Id { get; set; }
    }
}
