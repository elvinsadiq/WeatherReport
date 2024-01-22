using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class LoginFailureTrackerRepository : Repository<LoginFailureTracker>, ILoginFailureTrackerRepository
    {
        private readonly AppDbContext _context;

        public LoginFailureTrackerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}