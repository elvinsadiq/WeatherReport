using Application.WeatherReportDetails.Commands.Request;
using Application.WeatherReportDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WeatherReportDetails.Handlers.CommandHandlers
{
    public class DeleteWeatherReportCommandHandler : IRequestHandler<DeleteWeatherReportCommandRequest, DeleteWeatherReportCommandResponse>
    {
        private readonly IWeatherReportRepository _repository;

        public DeleteWeatherReportCommandHandler(IWeatherReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteWeatherReportCommandResponse> Handle(DeleteWeatherReportCommandRequest request, CancellationToken cancellationToken)
        {
            var weatherreport = await _repository.GetAsync(x => x.Id == request.Id);

            if (weatherreport == null)
            {
                return new DeleteWeatherReportCommandResponse { IsSuccess = false };
            }

            _repository.Remove(weatherreport);
            await _repository.CommitAsync();

            return new DeleteWeatherReportCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}