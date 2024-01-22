using Application.CartDetails.AddToCartDetails.ProductModelDetail;
using Application.ProductDetails.ProductModelDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Commands.Response
{
    public class CartItemViewResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Subtotal { get; set; }
        public ColorResponse ProductImages { get; set; }
    }
}
