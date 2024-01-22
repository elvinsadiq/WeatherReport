using Application.FavoriteDetails.Commands.Response;
using MediatR;

namespace Application.FavoriteDetails.Commands.Request
{
    public class RemoveFromFavoriteCommandRequest : IRequest<RemoveFromFavoriteCommandResponse>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    }
}