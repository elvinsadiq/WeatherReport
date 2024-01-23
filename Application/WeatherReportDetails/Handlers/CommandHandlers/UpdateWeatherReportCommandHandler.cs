using Application.WeatherReportDetails.Commands.Request;
using Application.WeatherReportDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.WeatherReportDetails.Handlers.CommandHandlers
{
    public class UpdateWeatherReportCommandHandler : IRequestHandler<UpdateWeatherReportCommandRequest, UpdateWeatherReportCommandResponse>
    {
        private readonly IWeatherReportRepository _repository;
        private readonly IMapper _mapper;

        public UpdateWeatherReportCommandHandler(IWeatherReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateWeatherReportCommandResponse> Handle(UpdateWeatherReportCommandRequest request, CancellationToken cancellationToken)
        {
            var weatherreport = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, weatherreport);
            await _repository.UpdateAsync(weatherreport);

            return new UpdateWeatherReportCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}