// UpdateCountryCommandRequest.cs
using Application.CheckoutDetails.CountryDetails.Commands.Response;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Commands.Request
{
    public class UpdateCountryCommandRequest : IRequest<UpdateCountryCommandResponse>
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string Ccode { get; set; }
    }
}
