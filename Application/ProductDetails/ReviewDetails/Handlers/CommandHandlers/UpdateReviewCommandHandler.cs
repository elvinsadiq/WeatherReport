using Application.ReviewDetails.Commands.Request;
using Application.ReviewDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReviewDetails.Handlers.CommandHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, UpdateReviewCommandResponse>
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateReviewCommandResponse> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetAsync(x => x.Id == request.Id && x.AppUserId == request.AppUserId);

            if (review == null || review.AppUserId != request.AppUserId || review.ProductId != request.ProductId)
            {
                return new UpdateReviewCommandResponse
                {
                    IsSuccess = false,
                    Message = review == null ? "User cannot edit this review" :
                              review.AppUserId != request.AppUserId ? "User can only edit their own reviews" :
                              "User can only edit their own reviews for the specified product"
                };
            }

            if (request.Rate <= 5 && request.Rate >= 1)
            {
                _mapper.Map(request, review);
                await _repository.UpdateAsync(review);
                await _repository.CommitAsync();

                return new UpdateReviewCommandResponse
                {
                    IsSuccess = true
                };
            }
            else
            {
                return new UpdateReviewCommandResponse
                {
                    IsSuccess = false
                };
            }
        }
    }
}
