using Application.WeatherReportDetails.Queries.Request;
using Application.WeatherReportDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WeatherReportDetails.Handlers.QueryHandlers
{
    public class GetByIdWeatherReportQueryHandler : IRequestHandler<GetByIdWeatherReportQueryRequest, GetByIdWeatherReportQueryResponse>
    {
        private readonly IWeatherReportRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdWeatherReportQueryHandler(IWeatherReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdWeatherReportQueryResponse> Handle(GetByIdWeatherReportQueryRequest request, CancellationToken cancellationToken)
        {
            var weatherreport = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (weatherreport != null)
            {
                var response = _mapper.Map<GetByIdWeatherReportQueryResponse>(weatherreport);
                return response;
            }

            return new GetByIdWeatherReportQueryResponse();
        }
    }
}