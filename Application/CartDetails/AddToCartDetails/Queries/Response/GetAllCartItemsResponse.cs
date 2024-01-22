using Application.CartDetails.AddToCartDetails.Commands.Response;
using Application.CartDetails.AddToCartDetails.ProductModelDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Queries.Response
{
    public class GetAllCartItemsResponse
    {
        public List<CartItemViewResponse> CartItems { get; set; }
    }
}
