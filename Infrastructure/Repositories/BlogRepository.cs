using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly AppDbContext _context;
        public BlogRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}