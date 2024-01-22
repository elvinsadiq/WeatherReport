using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}