using Application.CheckoutDetails.ProvinceDetails.Commands.Response;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Commands.Request
{
    public class UpdateProvinceCommandRequest : IRequest<UpdateProvinceCommandResponse>
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string ProvinceName { get; set; }
    }
}