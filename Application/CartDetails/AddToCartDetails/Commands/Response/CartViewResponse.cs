using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Commands.Response
{
    public class CartViewResponse
    {
        public int UserId { get; set; }
        public List<CartItemViewResponse> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
