using Application.ProductDescriptionDetails.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDescriptionDetails.Queries.Request
{
    public class GetByIdProductDescriptionQueryRequest : IRequest<GetByIdProductDescriptionQueryResponse>
    {
        public int Id { get; set; }
    }
}
