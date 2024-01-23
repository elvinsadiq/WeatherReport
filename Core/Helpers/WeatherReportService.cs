using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net;
using System.Xml.Linq;

namespace Core.Helpers
{
    public class WeatherReportService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWeatherReportRepository _weatherReportRepository;
        private readonly IDistrictRepository _districtRepository;
        private const string API_KEY = "83658b5db1d301515fe6cce116119bef";

        public WeatherReportService(IServiceProvider serviceProvider, IWeatherReportRepository weatherReportRepository, IDistrictRepository districtRepository)
        {
            _serviceProvider = serviceProvider;
            _weatherReportRepository = weatherReportRepository;
            _districtRepository = districtRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var districtRepository = _districtRepository.GetAll(x => true).ToList();

                        foreach (var district in districtRepository)
                        {
                            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={district.Latitude}&lon={district.Longitude}&appid={API_KEY}";

                            using (var httpClient = new HttpClient())
                            {
                                var response = await httpClient.GetAsync(url, stoppingToken);

                                if (response.IsSuccessStatusCode)
                                {
                                    var content = await response.Content.ReadAsStringAsync();
                                    Console.WriteLine(content);
                                    // Parse and save the content to the database as needed

                                    //var weatherreport = _mapper.Map<WeatherReport>(request);

                                    //await _repository.AddAsync(weatherreport);
                                    //await _repository.CommitAsync();
                                }
                                else
                                {
                                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message); ;
                }
            }
        }
    }
}
