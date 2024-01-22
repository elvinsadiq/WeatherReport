using Application.ReviewDetails.Commands.Response;
using MediatR;

namespace Application.ReviewDetails.Commands.Request
{
    public class UpdateReviewCommandRequest : IRequest<UpdateReviewCommandResponse>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AppUserId { get; set; }
        public float Rate { get; set; }
        public string Text { get; set; }
    }
}