using Application.CartDetails.AddToCartDetails.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Commands.Request
{
    public class CartRequest : IRequest<CartResponse>
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int UserId { get; set; }
        public int  Count { get; set; }
    }
}
