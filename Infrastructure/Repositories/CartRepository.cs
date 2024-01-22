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
    public class CartRepository : Repository<CartItem>, ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(int appUserId)
        {
            return await _context.CartItems
                .Where(c => c.AppUserId == appUserId)
                .ToListAsync();
        }
    }
}
