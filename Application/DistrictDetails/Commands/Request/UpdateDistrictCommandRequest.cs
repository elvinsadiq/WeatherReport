using Application.DistrictDetails.Commands.Response;
using MediatR;

namespace Application.DistrictDetails.Commands.Request
{
    public class UpdateDistrictCommandRequest : IRequest<UpdateDistrictCommandResponse>
    {
        public int Id { get; set; }
        // Add properties relevant to the Update operation if needed
    }
}