using Application.WeatherReportDetails.Queries.Request;
using Application.WeatherReportDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WeatherReportDetails.Handlers.QueryHandlers
{
    public class GetAllWeatherReportQueryHandler : IRequestHandler<GetAllWeatherReportQueryRequest, List<GetAllWeatherReportQueryResponse>>
    {
        private readonly IWeatherReportRepository _repository;
        private readonly IMapper _mapper;

        public GetAllWeatherReportQueryHandler(IWeatherReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllWeatherReportQueryResponse>> Handle(GetAllWeatherReportQueryRequest request, CancellationToken cancellationToken)
        {
            var weatherreports = _repository.GetAll(x => true);

            if (weatherreports != null)
            {
                List<GetAllWeatherReportQueryResponse> response = _mapper.Map<List<GetAllWeatherReportQueryResponse>>(weatherreports);
                return response;
            }
            
            return new List<GetAllWeatherReportQueryResponse>();
            
        }
    }
}