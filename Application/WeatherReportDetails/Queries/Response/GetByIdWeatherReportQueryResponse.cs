using Domain.Entities;

namespace Application.WeatherReportDetails.Queries.Response
{
    public class GetByIdWeatherReportQueryResponse
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public int WeatherId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public float Temp { get; set; }
        public float FeelsLike { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float SeaLevel { get; set; }
        public float GroundLevel { get; set; }
        public float WindSpeed { get; set; }
        public float WindDegree { get; set; }
        public float WindGust { get; set; }
        public float Clouds { get; set; }
    }
}