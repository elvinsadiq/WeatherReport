// DeleteCountryCommandRequest.cs
using Application.CheckoutDetails.CountryDetails.Commands.Response;
using MediatR;

namespace Application.CheckoutDetails.CountryDetails.Commands.Request
{
    public class DeleteCountryCommandRequest : IRequest<DeleteCountryCommandResponse>
    {
        public int Id { get; set; }
    }
}
