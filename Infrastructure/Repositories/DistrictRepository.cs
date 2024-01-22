using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        private readonly AppDbContext _context;

        public DistrictRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}