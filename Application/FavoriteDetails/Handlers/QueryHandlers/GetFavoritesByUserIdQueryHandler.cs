using Application.CartDetails.AddToCartDetails.ProductModelDetail;
using Application.Common.Interfaces;
using Application.FavoriteDetails.Queries.Request;
using Application.FavoriteDetails.Queries.Response;
using Application.ProductDetails.ProductModelDetail;
using Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.FavoriteDetails.Handlers.QueryHandlers
{
    public class GetFavoritesByUserIdQueryHandler : IRequestHandler<GetFavoritesByUserIdQueryRequest, List<GetFavoritesByUserIdQueryResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpAccessor;
        public GetFavoritesByUserIdQueryHandler(IApplicationDbContext context, IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _httpAccessor = httpAccessor;
        }
        public async Task<List<GetFavoritesByUserIdQueryResponse>> Handle(GetFavoritesByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var baseUrl = RequestExtensions.BaseUrl(_httpAccessor.HttpContext);
            List<FavoriteResponse> favoriteItems = await _context.Favorites.Include(m => m.Product).ThenInclude(m => m.ProductImages)
                 .Where(x => x.UserId == request.UserId)
                 .Select(item => new FavoriteResponse
                 {
                     ProductId = item.ProductId,
                     Title = item.Product.Title,
                     SubTitle = item.Product.SubTitle,
                     SalePrice = item.Product.CalculateSalePrice(),
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
                 }).ToListAsync();

            var response = new List<GetFavoritesByUserIdQueryResponse>
            {
                new GetFavoritesByUserIdQueryResponse
                {
                    Favorites = favoriteItems
                }
            };
            return response;
        }
    }
}