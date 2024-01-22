using Application.BlogDetails.Commands.Response;
using Application.HomeDetails.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.HomeDetails.Commands.Request
{
    public class CreateHomeCommandRequest : IRequest<CreateHomeCommandResponse>
    {
        public List<IFormFile> Images { get; set; }
    }
}