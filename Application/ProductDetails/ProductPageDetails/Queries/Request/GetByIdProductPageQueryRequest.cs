using Application.ProductPageDetails.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductPageDetails.Queries.Request
{
    public class GetByIdProductPageQueryRequest: IRequest<GetByIdProductPageQueryResponse>
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
    }
}
