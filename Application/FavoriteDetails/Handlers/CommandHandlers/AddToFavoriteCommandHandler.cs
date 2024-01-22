using Application.Common.Interfaces;
using Application.FavoriteDetails.Commands.Request;
using Application.FavoriteDetails.Commands.Response;
using Application.FavoriteDetails.Queries.Response;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FavoriteDetails.Handlers.CommandHandlers
{
    public class AddToFavoriteCommandHandler : IRequestHandler<AddToFavoriteCommandRequest, AddToFavoriteCommandResponse>
    {
        private readonly IFavoriteRepository _repository;
        private readonly IAppUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IApplicationDbContext _context;
        private readonly IProductColorStockRepository _productColorStockRepository;
        public AddToFavoriteCommandHandler(IFavoriteRepository repository, IAppUserRepository userRepository, IProductRepository productRepository, IApplicationDbContext context, IProductColorStockRepository productColorStockRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _context = context;
            _productColorStockRepository = productColorStockRepository;
        }
        public async Task<AddToFavoriteCommandResponse> Handle(AddToFavoriteCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                return new AddToFavoriteCommandResponse { IsSuccess = false, Message = "User does not exist" };
            }

            var product = await _productRepository.GetAsync(x => x.Id == request.ProductId);
            if (product == null)
            {
                return new AddToFavoriteCommandResponse { IsSuccess = false, Message = "Product doesn't found" };
            }
            var colorStock = await _productColorStockRepository
                .GetAsync(pc => pc.ProductId == request.ProductId && pc.ColorId == request.ColorId) ?? throw new ApplicationException("Product does not exist in stock.");

            var favoriteItem = await _repository.FirstOrDefaultAsync(
                x => x.UserId == request.UserId && x.ProductId == request.ProductId
            );

            if (favoriteItem == null)
            {
                favoriteItem = new Favorite
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    User = user,
                    Product = product,
                    ColorId = request.ColorId,
                    Color = colorStock.Color
                };

                await _repository.AddAsync(favoriteItem);
                await _repository.CommitAsync();
            }
            else
            {
                _repository.Remove(favoriteItem);
                await _repository.CommitAsync();
            }

            List<FavoriteResponse> favorite = await _context.Favorites
            .Where(x => x.UserId == request.UserId)
            .Select(item => new FavoriteResponse
            {
                ProductId = item.ProductId,
                Title = item.Product.Title,
                SalePrice = item.Product.CalculateSalePrice(),
            })
            .ToListAsync();
            await _context.SaveChangesAsync(cancellationToken);

            var favoriteModel = new GetFavoritesByUserIdQueryResponse
            {
                Favorites = favorite,
            };
            return new AddToFavoriteCommandResponse { IsSuccess = true, Message = "Product added to favorites" };
        }
    }
}