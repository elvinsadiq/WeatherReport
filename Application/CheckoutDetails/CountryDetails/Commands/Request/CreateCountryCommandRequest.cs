// CreateCountryCommandRequest.cs
using Application.CheckoutDetails.CountryDetails.Commands.Response;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Commands.Request
{
    public class CreateCountryCommandRequest : IRequest<CreateCountryCommandResponse>
    {
        public string CountryName { get; set; }
        public string Ccode { get; set; }
    }
}
