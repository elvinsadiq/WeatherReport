using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class HomeRepository : Repository<Home>, IHomeRepository
    {
        private readonly AppDbContext _context;
        public HomeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}