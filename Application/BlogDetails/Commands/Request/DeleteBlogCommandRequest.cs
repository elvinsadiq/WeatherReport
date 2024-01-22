using Application.BlogDetails.Commands.Response;
using MediatR;

namespace Application.BlogDetails.Commands.Request
{
    public class DeleteBlogCommandRequest : IRequest<DeleteBlogCommandResponse>
    {
        public int Id { get; set; }
    }
}