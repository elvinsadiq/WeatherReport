using Application.FavoriteDetails.Commands.Response;
using MediatR;

namespace Application.FavoriteDetails.Commands.Request
{
    public class AddToFavoriteCommandRequest : IRequest<AddToFavoriteCommandResponse>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    }
}