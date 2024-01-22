using Application.DistrictDetails.Commands.Response;
using MediatR;

namespace Application.DistrictDetails.Commands.Request
{
    public class UpdateDistrictCommandRequest : IRequest<UpdateDistrictCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}