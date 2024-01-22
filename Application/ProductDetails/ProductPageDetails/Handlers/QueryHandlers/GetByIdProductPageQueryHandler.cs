using Application.ProductPageDetails.Queries.Request;
using Application.ProductPageDetails.Queries.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductPageDetails.Handlers.QueryHandlers
{
    public class GetByIdProductPageQueryHandler : IRequestHandler<GetByIdProductPageQueryRequest, GetByIdProductPageQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetByIdProductPageQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetByIdProductPageQueryResponse> Handle(GetByIdProductPageQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = _productRepository.Get(x => x.Id == request.Id, "ProductSizes.Size", "ProductTags.Tag", "ProductImages", "ProductImages.Color", "Category");
            if (product == null)
                return null;

            switch (request.SizeId)
            {
                case 1:
                    break;
                case 2:
                    product.SalePrice += 100;
                    break;
                case 3:
                    product.SalePrice += 200;
                    break;
                case 4:
                    product.SalePrice += 300;
                    break;
                case 5:
                    product.SalePrice += 400;
                    break;
                default:
                    break;
            }

            GetByIdProductPageQueryResponse getByIdCategoryResponse = _mapper.Map<GetByIdProductPageQueryResponse>(product);
            return getByIdCategoryResponse;
        }
    }
}
