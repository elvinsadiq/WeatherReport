using Application.CartDetails.AddToCartDetails.Commands.Request;
using Application.CartDetails.AddToCartDetails.Commands.Response;
using Application.CartDetails.AddToCartDetails.ProductModelDetail;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Handlers.CommandHandler
{
    public class AddToCartHandler : IRequestHandler<CartRequest, CartResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductColorStockRepository _productColorStockRepository;
        private readonly IApplicationDbContext _context;

        public AddToCartHandler(ICartRepository cartRepository, IAppUserRepository appUserRepository, IProductRepository productRepository, IApplicationDbContext context, IProductColorStockRepository productColorStockRepository)
        {
            _cartRepository = cartRepository;
            _appUserRepository = appUserRepository;
            _productRepository = productRepository;
            _context = context;
            _productColorStockRepository = productColorStockRepository;
        }

        public async Task<CartResponse> Handle(CartRequest request, CancellationToken cancellationToken)
        {

            if (request.Count <= 0)
            {
                return new CartResponse { Success = false, Message = "The quantity of the product cannot be 0 or less." };
            }

            var user = await _appUserRepository.GetUserByIdAsync(request.UserId) ?? throw new ApplicationException("User not found.");
            var product = await _productRepository.GetAsync(x => x.Id == request.ProductId) ?? throw new ApplicationException("Product not found.");

            var colorStock = await _productColorStockRepository
                .GetAsync(pc => pc.ProductId == request.ProductId && pc.ColorId == request.ColorId) ?? throw new ApplicationException("We're sorry, the product is not in stock.");

            if (colorStock.StockCount == 0 || colorStock.StockCount < request.Count)
            {
                return new CartResponse { Success = false, Message = "We're sorry, there is not enough quantity of the product in stock." };
            }

            var cartItem = await _cartRepository
                .FirstOrDefaultAsync(x => x.AppUserId == request.UserId && x.ProductId == request.ProductId && x.ColorId == request.ColorId);

            if (cartItem != null && cartItem.Count + request.Count > 10 || request.Count > 10)
            {
                return new CartResponse { Success = false, Message = "We're sorry, you cannot add more than a total of 10 of the same product." };
            }

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    AppUserId = request.UserId,
                    ProductId = request.ProductId,
                    ColorId = request.ColorId,
                    Count = request.Count, 
                    AppUser = user,
                    Product = product,
                    Color = colorStock.Color
                };
                await _cartRepository.AddAsync(cartItem);
            }
            else
            {
                if (cartItem.Count + request.Count > 10)
                {
                    return new CartResponse { Success = false, Message = "We're sorry, you cannot add more than a total of 10 of the same product." };
                }

                cartItem.Count += request.Count;
                await _cartRepository.UpdateAsync(cartItem);
            }

            colorStock.StockCount -= request.Count;
            await _productRepository.UpdateAsync(product);
            await _productColorStockRepository.UpdateAsync(colorStock);
            await _context.SaveChangesAsync(cancellationToken);

            var cart = await _context.CartItems
                .Where(x => x.AppUserId == request.UserId)
                .Select(item => new CartItemViewResponse
                {
                    ProductId = item.ProductId,
                    ProductTitle = item.Product.Title,
                    Count = item.Count,
                    SalePrice = item.Product.CalculateSalePrice(),
                    Subtotal = item.Count * item.Product.CalculateSalePrice(),
                })
                .ToListAsync();

            var cartViewModel = new CartViewResponse
            {
                UserId = request.UserId,
                CartItems = cart,
                TotalPrice = cart.Sum(item => item.Subtotal)
            };
            return new CartResponse { Success = true, Message = "The product has been added to the cart.", Cart = cartViewModel };
        }
    }
}

