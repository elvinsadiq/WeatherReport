using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        private readonly AppDbContext _context;

        public ColorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Color> GetByIdAsync(int id, params string[] includes)
        {
            var query = _context.Set<Color>().AsQueryable();

            if (includes != null)
            {
                foreach (var reff in includes)
                {
                    query = query.Include(reff);
                }
            }

            return await query.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
