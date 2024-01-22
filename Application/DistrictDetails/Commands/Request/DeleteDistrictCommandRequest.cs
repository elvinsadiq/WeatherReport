using Application.DistrictDetails.Commands.Response;
using MediatR;

namespace Application.DistrictDetails.Commands.Request
{
    public class DeleteDistrictCommandRequest : IRequest<DeleteDistrictCommandResponse>
    {
        public int Id { get; set; }
    }
}