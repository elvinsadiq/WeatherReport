using Application.CheckoutDetails.ProvinceDetails.Commands.Response;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Commands.Request
{
    public class DeleteProvinceCommandRequest : IRequest<DeleteProvinceCommandResponse>
    {
        public int Id { get; set; }
    }
}