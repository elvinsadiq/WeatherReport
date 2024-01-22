using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}