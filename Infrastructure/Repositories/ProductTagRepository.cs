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
    public class ProductTagRepository : Repository<ProductTag>, IProductTagRepository
    {
        private readonly AppDbContext _context;

        public ProductTagRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
