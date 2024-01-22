using Application.RelatedProductsDetails.Queries.Request;
using Application.RelatedProductsDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RelatedProductsDetails.Handlers.QueryHandlers
{
    public class GetRelatedProductsQueryHandler : IRequestHandler<GetRelatedProductsQueryRequest, List<GetRelatedProductsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetRelatedProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<GetRelatedProductsQueryResponse>> Handle(GetRelatedProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var mainProduct = await _productRepository.GetAsync(x => x.Id == request.MainProductId);
            if (mainProduct == null)
            {
                return new List<GetRelatedProductsQueryResponse>();
            }

            var query = _productRepository.GetAll(x => x.CategoryId == mainProduct.CategoryId && x.Id != mainProduct.Id, "ProductImages");
            var response = _mapper.Map<List<GetRelatedProductsQueryResponse>>(query.Skip((request.Page - 1) * request.ShowMore.Take).Take(request.ShowMore.Take));

            foreach (var productResponse in response)
            {
                productResponse.ImageFiles = productResponse.ImageFiles.Any() ? new List<string> { productResponse.ImageFiles.First() } : new List<string>();
            }

            PaginationListDto<GetRelatedProductsQueryResponse> model =
                new PaginationListDto<GetRelatedProductsQueryResponse>(response, request.Page, request.ShowMore.Take, query.Count());

            return model.Items;
        }
    }
}
