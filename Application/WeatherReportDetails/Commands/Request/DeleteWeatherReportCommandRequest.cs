using Application.WeatherReportDetails.Commands.Response;
using MediatR;

namespace Application.WeatherReportDetails.Commands.Request
{
    public class DeleteWeatherReportCommandRequest : IRequest<DeleteWeatherReportCommandResponse>
    {
        public int Id { get; set; }
        // Add properties relevant to the Delete operation if needed
    }
}