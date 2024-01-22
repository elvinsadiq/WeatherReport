using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DescriptionRepository : Repository<Description>, IDescriptionRepository
    {
        private readonly AppDbContext _context;

        public DescriptionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
