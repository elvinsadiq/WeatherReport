using Application.GetProductDetails;
using Application.GetProductDetails.Queries.Response;
using Application.NewProductDetails.Queries.Request;
using Application.NewProductDetails.Queries.Response;
using Application.ProductDetails.NewProductDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.NewProductDetails.Handlers.QueryHandlers
{
    public class GetNewProductsQueryHandler : IRequestHandler<GetNewProductsQueryRequest, List<GetListNewProductsQueryResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetNewProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetListNewProductsQueryResponse>> Handle(GetNewProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(p => p.IsNew == true).Include(p => p.ProductImages);

            var response = new List<GetNewProductsQueryResponse>();
            var selectExpression = products.Select(product => _mapper.Map<GetNewProductsQueryResponse>(product));

            response = request.ShowMore == null || request.ShowMore.Take <= 0 ? selectExpression.ToList()
            : selectExpression.Skip((request.Page - 1) * request.ShowMore.Take).Take(request.ShowMore.Take).ToList();


            var totalProductCount = products.ToList().Count();

            return new List<GetListNewProductsQueryResponse>
            {
                  new GetListNewProductsQueryResponse
                {
                    TotalProductCount = totalProductCount,
                    NewProducts = response
                 }
            };
        }
    }
}
