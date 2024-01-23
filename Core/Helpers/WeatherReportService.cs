using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.IRepositories;
using System.Text.Json;
using Domain.Entities;

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
                await Task.Delay(TimeSpan.FromHours(3), stoppingToken);

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

                                    var options = new JsonSerializerOptions
                                    {
                                        PropertyNameCaseInsensitive = true, // Handle case-insensitive property names
                                    };

                                    var weatherData = JsonSerializer.Deserialize<WeatherApiDto>(content, options);

                                    var weatherReport = new WeatherReport
                                    {
                                        DistrictId = district.Id, // Assuming Id is the primary key of District
                                        WeatherId = weatherData.Weather[0].Id,
                                        Main = weatherData.Weather[0].Main,
                                        Description = weatherData.Weather[0].Description,
                                        Icon = weatherData.Weather[0].Icon,
                                        Temp = weatherData.Main.Temp,
                                        FeelsLike = weatherData.Main.Feels_Like,
                                        TempMin = weatherData.Main.Temp_Min,
                                        TempMax = weatherData.Main.Temp_Max,
                                        Pressure = weatherData.Main.Pressure,
                                        Humidity = weatherData.Main.Humidity,
                                        SeaLevel = weatherData.Main.Sea_Level,
                                        GroundLevel = weatherData.Main.Grnd_Level,
                                        WindSpeed = weatherData.Wind.Speed,
                                        WindDegree = weatherData.Wind.Deg,
                                        WindGust = weatherData.Wind.Gust,
                                        Clouds = weatherData.Clouds.All
                                    };


                                    await _weatherReportRepository.AddAsync(weatherReport);
                                    await _weatherReportRepository.CommitAsync();
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

    public class WeatherApiDto
    {
        public Coord Coord { get; set; }
        public Weather[] Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Coord
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float Sea_Level { get; set; }
        public float Grnd_Level { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }
        public float Deg { get; set; }
        public float Gust { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
