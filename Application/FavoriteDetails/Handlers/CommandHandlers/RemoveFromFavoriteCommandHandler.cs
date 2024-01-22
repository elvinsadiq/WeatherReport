using Application.Common.Interfaces;
using Application.FavoriteDetails.Commands.Request;
using Application.FavoriteDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FavoriteDetails.Handlers.CommandHandlers
{
    public class RemoveFromFavoriteCommandHandler : IRequestHandler<RemoveFromFavoriteCommandRequest, RemoveFromFavoriteCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        public RemoveFromFavoriteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RemoveFromFavoriteCommandResponse> Handle(RemoveFromFavoriteCommandRequest request, CancellationToken cancellationToken)
        {
            var favoriteItem = await _context.Favorites
                .SingleOrDefaultAsync(x => x.UserId == request.UserId && x.ProductId == request.ProductId, cancellationToken: cancellationToken);
            if (favoriteItem != null)
            {
                _context.Favorites.Remove(favoriteItem);
                await _context.SaveChangesAsync(cancellationToken);

                return new RemoveFromFavoriteCommandResponse { IsSuccess = true, Message = "Product removed successfully" };
            }
            else
            {
                return new RemoveFromFavoriteCommandResponse { IsSuccess = false, Message = "Product not found " };
            }
        }
    }
}