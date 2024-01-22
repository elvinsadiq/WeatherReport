using Application.ProductDetails.ReviewDetails.Queries.Response;
using Application.ReviewDetails.Queries.Request;
using Application.ReviewDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.ReviewDetails.Handlers.QueryHandlers
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQueryRequest, GetProductReviewListResponse> 
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public GetAllReviewQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductReviewListResponse> Handle(GetAllReviewQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = _repository.GetAll(x => x.ProductId == request.ProductId);

            var reviewResponses = _mapper.Map<List<GetAllReviewQueryResponse>>(reviews
                .Skip((request.Page - 1) * request.ShowMore.Take)
                .Take(request.ShowMore.Take));
            reviewResponses = reviewResponses.OrderByDescending(x=>x.CreatedAt).ToList();
            var totalReviewCount = reviews.Count();

            var response = new GetProductReviewListResponse
            {
                TotalReviewCount = totalReviewCount,
                ProductReviews = reviewResponses
            };

            return response;
        }
    }
}

