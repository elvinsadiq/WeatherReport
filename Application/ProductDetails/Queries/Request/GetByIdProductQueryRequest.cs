using Application.ProductDetails.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.Queries.Request
{
    public class GetByIdProductQueryRequest: IRequest<GetByIdProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
