using Application.ProductDetails;
using Application.RelatedProductsDetails.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RelatedProductsDetails.Queries.Request
{
    public class GetRelatedProductsQueryRequest : IRequest<List<GetRelatedProductsQueryResponse>>
    {
        public int Page { get; set; } = 1;
        public ShowMoreDto ShowMore { get; set; }
        public int MainProductId { get; set; }
    }
}
