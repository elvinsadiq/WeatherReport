using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Commands.Response
{
    public class CartResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public CartViewResponse Cart { get; set; }
    }
}
