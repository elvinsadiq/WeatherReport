using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<District> Districts { get; set; }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}