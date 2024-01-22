using Application.CartDetails.AddToCartDetails.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartDetails.AddToCartDetails.Queries.Request
{
    public class GetAllCartItemsRequest : IRequest<List<GetAllCartItemsResponse>>
    {
        public int UserId { get; set; }
    }
}
