using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class WeatherReportRepository : Repository<WeatherReport>, IWeatherReportRepository
    {
        private readonly AppDbContext _context;

        public WeatherReportRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}