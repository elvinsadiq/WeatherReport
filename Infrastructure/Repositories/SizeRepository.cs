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
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        private readonly AppDbContext _context;

        public SizeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
