using Application.BlogDetails.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.BlogDetails.Commands.Request
{
    public class UpdateBlogImageCommandRequest : IRequest<UpdateBlogCommandResponse>
    {
        public int Id { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}