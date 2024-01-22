using Application.DistrictDetails.Commands.Response;
using MediatR;

namespace Application.DistrictDetails.Commands.Request
{
    public class DeleteDistrictCommandRequest : IRequest<DeleteDistrictCommandResponse>
    {
        public int Id { get; set; }
        // Add properties relevant to the Delete operation if needed
    }
}