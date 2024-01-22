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
    public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
    {
        private readonly AppDbContext _context;

        public ProductSizeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
