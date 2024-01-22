using Application.CartDetails.RemoveFromCartDetails.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.RemoveFromCartDetails.Commands.Request
{
    public class RemoveFromCartRequest : IRequest<RemoveFromCartResponse>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    }
}
