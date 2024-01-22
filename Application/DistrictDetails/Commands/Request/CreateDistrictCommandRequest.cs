using Application.DistrictDetails.Commands.Response;
using MediatR;

namespace Application.DistrictDetails.Commands.Request
{
    public class CreateDistrictCommandRequest : IRequest<CreateDistrictCommandResponse>
    {
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}