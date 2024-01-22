using Application.ProductDetails;
using Application.RelatedCategoryProductDetails.Queries.Response;
using MediatR;

namespace Application.RelatedCategoryProductDetails.Queries.Request
{
    public class GetRelatedCategoryProductQueryRequest : IRequest<List<GetRelatedCategoryProductQueryResponse>>
    {
        public int CategoryId { get; set; }
        public int Page { get; set; } = 1;
        public ShowMoreDto ShowMore { get; set; }
    }
}