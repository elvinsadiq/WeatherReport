using Application.DistrictDetails.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.DistrictDetails.Commands.Request
{
    public class UploadDistrictCommandRequest : IRequest<UploadDistrictCommandResponse>
    {
        public IFormFile XmlData { get; set; }
    }
}