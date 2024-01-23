using Application.WeatherReportDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.WeatherReportDetails.Queries.Request
{
    public class GetAllWeatherReportQueryRequest : IRequest<List<GetAllWeatherReportQueryResponse>>
    {
    }
}