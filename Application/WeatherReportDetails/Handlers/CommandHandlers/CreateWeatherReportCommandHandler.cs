using Application.WeatherReportDetails.Commands.Request;
using Application.WeatherReportDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WeatherReportDetails.Handlers.CommandHandlers
{
    public class CreateWeatherReportCommandHandler : IRequestHandler<CreateWeatherReportCommandRequest, CreateWeatherReportCommandResponse>
    {
        private readonly IWeatherReportRepository _repository;
        private readonly IMapper _mapper;

        public CreateWeatherReportCommandHandler(IWeatherReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateWeatherReportCommandResponse> Handle(CreateWeatherReportCommandRequest request, CancellationToken cancellationToken)
        {
            var weatherReport = _mapper.Map<WeatherReport>(request);

            await _repository.AddAsync(weatherReport);
            await _repository.CommitAsync();

            return new CreateWeatherReportCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}