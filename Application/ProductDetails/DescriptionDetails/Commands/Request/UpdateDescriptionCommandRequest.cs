using Application.DescriptionDetails.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.DescriptionDetails.Commands.Request
{
    public class UpdateDescriptionCommandRequest
    {
        public int Id { get; set; }
        public string Introduction { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
