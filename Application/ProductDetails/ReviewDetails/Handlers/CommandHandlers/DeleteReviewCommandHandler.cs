using Application.ReviewDetails.Commands.Request;
using Application.ReviewDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReviewDetails.Handlers.CommandHandlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, DeleteReviewCommandResponse>
    {
        private readonly IReviewRepository _repository;

        public DeleteReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteReviewCommandResponse> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetAsync(x => x.Id == request.Id && x.AppUserId == request.AppUserId && x.ProductId == request.ProductId);

            if (review == null)
            {
                return new DeleteReviewCommandResponse { IsSuccess = false };
            }

            _repository.Remove(review);
            await _repository.CommitAsync();

            return new DeleteReviewCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}