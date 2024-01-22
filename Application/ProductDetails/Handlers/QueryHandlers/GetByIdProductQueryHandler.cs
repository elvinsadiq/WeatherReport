using Application.ProductDetails.Queries.Request;
using Application.ProductDetails.Queries.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = _productRepository.Get(x => x.Id == request.Id, "ProductSizes.Size", "ProductTags.Tag", "ProductImages", "ProductImages.Color", "Description", "Description.DescriptionImages");
            if (product == null)
                return null;

            GetByIdProductQueryResponse getByIdCategoryResponse = _mapper.Map<GetByIdProductQueryResponse>(product);
            return getByIdCategoryResponse;
        }
    }
}
