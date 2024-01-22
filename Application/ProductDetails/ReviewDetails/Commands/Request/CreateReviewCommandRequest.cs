using Application.ReviewDetails.Commands.Response;
using Domain.Entities;
using MediatR;

namespace Application.ReviewDetails.Commands.Request
{
    public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
    {
        public int ProductId { get; set; }
        public int AppUserId { get; set; }
        public float Rate { get; set; }
        public string Text { get; set; }
    }
}