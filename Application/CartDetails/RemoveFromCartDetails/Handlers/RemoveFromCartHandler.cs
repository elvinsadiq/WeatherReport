using Application.Common.Interfaces;
using Application.CartDetails.RemoveFromCartDetails.Commands.Request;
using Application.CartDetails.RemoveFromCartDetails.Commands.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.RemoveFromCartDetails.Handlers
{
    public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartRequest, RemoveFromCartResponse>
    {
        private readonly IApplicationDbContext _context;

        public RemoveFromCartHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RemoveFromCartResponse> Handle(RemoveFromCartRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await _context.CartItems
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductColorStocks)
                .SingleOrDefaultAsync(x => x.AppUserId == request.UserId &&
                                            x.ProductId == request.ProductId &&
                                            x.ColorId == request.ColorId);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);

                var colorStock = cartItem.Product.ProductColorStocks
                    .SingleOrDefault(c => c.ColorId == request.ColorId);

                if (colorStock != null)
                {
                    colorStock.StockCount += cartItem.Count;
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return new RemoveFromCartResponse { Success = true, Message = "The product has been removed from the cart." };
            }

            return new RemoveFromCartResponse { Success = false, Message = "The product could not be found in your cart." };
        }
    }
}
