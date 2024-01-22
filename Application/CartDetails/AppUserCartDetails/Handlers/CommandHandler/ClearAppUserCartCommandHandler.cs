using Application.AppUserCartDetails.Commands.Request;
using Application.AppUserCartDetails.Commands.Response;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.AppUserCartDetails.Handlers.CommandHandler
{
    public class ClearAppUserCartCommandHandler : IRequestHandler<ClearAppUserCartCommandRequest, ClearAppUserCartCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public ClearAppUserCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClearAppUserCartCommandResponse> Handle(ClearAppUserCartCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var basketItems = await _context.CartItems
                    .Where(x => x.AppUserId == request.AppUserId)
                    .ToListAsync();

                if (basketItems.Count > 0)
                {
                    _context.CartItems.RemoveRange(basketItems);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ClearAppUserCartCommandResponse { IsSuccess = true, Message = "Cart cleared" };
                }
                else
                {
                    return new ClearAppUserCartCommandResponse { IsSuccess = false, Message = "The cart is already empty" };
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return new ClearAppUserCartCommandResponse { IsSuccess = false, Message = "Error while clearing the cart" };
            }
        }
    }
}
