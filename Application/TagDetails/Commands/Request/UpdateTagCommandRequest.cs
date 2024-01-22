using Application.TagDetails.Commands.Response;
using MediatR;

namespace Application.TagDetails.Commands.Request
{
    public class UpdateTagCommandRequest : IRequest<UpdateTagCommandResponse>
    {
        public int Id { get; set; }
        public string TagName { get; set; } 
    }
}