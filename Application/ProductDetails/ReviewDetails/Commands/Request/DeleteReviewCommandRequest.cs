using Application.ReviewDetails.Commands.Response;
using MediatR;

namespace Application.ReviewDetails.Commands.Request
{
    public class DeleteReviewCommandRequest : IRequest<DeleteReviewCommandResponse>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AppUserId { get; set; }
    }
}