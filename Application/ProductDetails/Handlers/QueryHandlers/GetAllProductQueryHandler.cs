using Application.ProductDetails.Queries.Request;
using Application.ProductDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductDetails.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public GetAllProductQueryHandler(IMapper mapper, IProductRepository productRepository, IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetAll(x => true).Include(p => p.ProductSizes)
                .ThenInclude(ps => ps.Size)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.ProductImages)
                .ThenInclude(pc => pc.Color)
                .Include(p => p.Description)
                .ThenInclude(p => p.DescriptionImages);

            var response = _mapper.Map<List<GetAllProductQueryResponse>>(query.Skip((request.Page - 1) * 3).Take(3));

            PaginationListDto<GetAllProductQueryResponse> model =
                new PaginationListDto<GetAllProductQueryResponse>(response, request.Page, 3, query.Count());

            return model.Items;
        }
    }
}
