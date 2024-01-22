using Application.CheckoutDetails.CountryDetails.Queries.Response;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Queries.Request
{
    public class GetAllCountryQueryRequest : IRequest<List<GetAllCountryQueryResponse>>
    {
    }
}