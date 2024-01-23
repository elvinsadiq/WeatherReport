using Application.WeatherReportDetails.Queries.Response;
using MediatR;

namespace Application.WeatherReportDetails.Queries.Request
{
    public class GetByIdWeatherReportQueryRequest : IRequest<GetByIdWeatherReportQueryResponse>
    {
        public int Id { get; set; }
    }
}