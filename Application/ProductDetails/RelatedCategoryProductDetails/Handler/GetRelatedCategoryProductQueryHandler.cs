using Application.RelatedCategoryProductDetails.Queries.Request;
using Application.RelatedCategoryProductDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NewProductDetails.Handlers.QueryHandlers
{
    public class GetRelatedCategoryProductQueryHandler : IRequestHandler<GetRelatedCategoryProductQueryRequest, List<GetRelatedCategoryProductQueryResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetRelatedCategoryProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetRelatedCategoryProductQueryResponse>> Handle(GetRelatedCategoryProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(p => p.CategoryId == request.CategoryId).Include(p => p.ProductImages);
            
            var response = _mapper.Map<List<GetRelatedCategoryProductQueryResponse>>(products.Skip((request.Page - 1) * request.ShowMore.Take).Take(request.ShowMore.Take));

            foreach (var productResponse in response)
            {
                productResponse.ImageFiles = productResponse.ImageFiles.Any() ? new List<string> { productResponse.ImageFiles.First() } : new List<string>();
            }
           
            return response;
        }
    }
}
