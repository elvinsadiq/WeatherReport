using Application.ReviewDetails.Queries.Request;
using Application.ReviewDetails.Queries.Response;
using Domain.IRepositories;
using MediatR;
using System.Runtime.InteropServices;

namespace Application.ReviewDetails.Handlers.QueryHandlers
{
    public class GetProductRatingQueryHandler : IRequestHandler<GetProductRatingQueryRequest, GetProductRatingQueryResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetProductRatingQueryHandler(IReviewRepository repository)
        {
            _reviewRepository = repository;
        }

        public async Task<GetProductRatingQueryResponse> Handle(GetProductRatingQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = _reviewRepository.GetAll(x => x.ProductId == request.ProductId);

            var totalReviewCount = reviews.Count();

            float totalReviewPoint = 0;

            foreach (var review in reviews)
            {
                totalReviewPoint += review.Rate;
            }

            var response = new GetProductRatingQueryResponse
            {
                Rate = (float)Math.Round(totalReviewPoint / totalReviewCount , 2) 
            };

            return response;
        }
    }
}