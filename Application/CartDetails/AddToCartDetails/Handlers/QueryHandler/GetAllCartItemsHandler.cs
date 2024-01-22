using Application.CartDetails.AddToCartDetails.Commands.Response;
using Application.CartDetails.AddToCartDetails.ProductModelDetail;
using Application.CartDetails.AddToCartDetails.Queries.Request;
using Application.CartDetails.AddToCartDetails.Queries.Response;
using Application.Common.Interfaces;
using Application.ProductDetails.ProductModelDetail;
using Core.Helpers;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Handlers.QueryHandler
{
    public class GetAllCartItemsHandler : IRequestHandler<GetAllCartItemsRequest, List<GetAllCartItemsResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpAccessor;

        public GetAllCartItemsHandler(IApplicationDbContext context, IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _httpAccessor = httpAccessor;
        }

        public async Task<List<GetAllCartItemsResponse>> Handle(GetAllCartItemsRequest request, CancellationToken cancellationToken)
        {

            var baseUrl = RequestExtensions.BaseUrl(_httpAccessor.HttpContext);

            var response = await _context.CartItems
                .Where(x => x.AppUserId == request.UserId)
                .Select(item => new GetAllCartItemsResponse
                {
                    CartItems = new List<CartItemViewResponse>
                    {
                        new CartItemViewResponse
                        {
                            Id = item.Id,
                            ProductId = item.ProductId,
                            ProductTitle = item.Product.Title,
                            Count = item.Count,
                            SalePrice = item.Product.CalculateSalePrice(),
                            Subtotal = item.Count * item.Product.CalculateSalePrice(),
                            ProductImages = _context.ProductImages
                        .Where(pi => pi.ProductId == item.ProductId)
                        .Where(pi => pi.ColorId == item.ColorId) 
                        .Select(pi => new ColorResponse
                        {
                            Id = pi.ColorId,
                            ColorHexCode = pi.Color.ColorHexCode,
                            ImageFiles = new List<string>
                            {
                                  $"{baseUrl}{pi.Image}"
                            }
                        })
                        .FirstOrDefault()
                        }
                    }
                })
                .ToListAsync();

            return response;
        }
    }
}
