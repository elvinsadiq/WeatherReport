using Application.DescriptionDetails.Commands.Request;
using Application.ProductDetails.Commands.Response;
using MediatR;

namespace Application.ProductDetails.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
