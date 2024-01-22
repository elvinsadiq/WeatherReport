using Application.Common.Interfaces;
using Application.GetProductDetails.Queries.Request;
using Application.GetProductDetails.Queries.Response;
using AutoMapper;
using Core.Helpers;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.GetProductDetails.Handlers.QueryHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, List<GetProductListResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IApplicationDbContext context, IProductRepository productRepository, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _context = context;
            _productRepository = productRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        public async Task<List<GetProductListResponse>> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();
            query = query.Include(p => p.ProductImages);
            var baseUrl = RequestExtensions.BaseUrl(_contextAccessor.HttpContext);

            query = !string.IsNullOrEmpty(request.Prompt) ? query.Where(p => EF.Functions.Like(p.Title.ToLower(), $"%{request.Prompt.ToLower()}%") || EF.Functions.Like(p.SubTitle.ToLower(), $"%{request.Prompt.ToLower()}%")) : query;

            query = (request.CategoryNames != null && request.CategoryNames.Any()) ? query.Where(p => p.Category != null && request.CategoryNames.Contains(p.Category.CategoryName)) : query;

            query = (request.IsNew.HasValue) ? query.Where(p => p.IsNew == request.IsNew.Value) : query;

            query = (request.ProductTags != null && request.ProductTags.Any()) ? query.Where(p => p.ProductTags.Any(pt => request.ProductTags.Contains(pt.Tag.TagName))) : query;

            query = (request.ProductSizes != null && request.ProductSizes.Any()) ? query.Where(p => p.ProductSizes.Any(ps => request.ProductSizes.Contains(ps.Size.SizeName))) : query;

            query = (request.ProductColors != null && request.ProductColors.Any()) ? query.Where(p => p.ProductImages.Any(pi => request.ProductColors.Contains(pi.Color.ColorHexCode))) : query;

            query = (request.MinPrice.HasValue) ? query.Where(p => p.SalePrice - (p.SalePrice * (p.DiscountPercent / 100)) >= request.MinPrice.Value) : query;

            query = (request.MaxPrice.HasValue) ? query.Where(p => p.SalePrice - (p.SalePrice * (p.DiscountPercent / 100)) <= request.MaxPrice.Value) : query;

            var orderedQuery = query;

            orderedQuery = string.IsNullOrEmpty(request.OrderBy) ? orderedQuery.OrderBy(p => p.Title) : request.OrderBy.ToLower() switch
            {
                "nameasc" => orderedQuery.OrderBy(p => p.Title),
                "namedesc" => orderedQuery.OrderByDescending(p => p.Title),
                "priceasc" => orderedQuery.OrderBy(p => p.SalePrice - (p.SalePrice * (p.DiscountPercent / 100))),
                "pricedesc" => orderedQuery.OrderByDescending(p => p.SalePrice - (p.SalePrice * (p.DiscountPercent / 100))),
                _ => orderedQuery.OrderBy(p => p.Title),
            };

            var response = new List<GetProductQueryResponse>();
            var selectExpression = orderedQuery.Select(product => _mapper.Map<GetProductQueryResponse>(product));

            response = request.ShowMore == null || request.ShowMore.Take <= 0 ? selectExpression.ToList()
            : selectExpression.Skip((request.Page - 1) * request.ShowMore.Take).Take(request.ShowMore.Take).ToList();

            var totalProductCount = query.ToList().Count();

            return new List<GetProductListResponse>
            {
                  new GetProductListResponse
                {
                    TotalProductCount = totalProductCount,
                    Products = response
                 }
            };
        }
    }
}