using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int AppUserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int Count { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }

        
    }
}
