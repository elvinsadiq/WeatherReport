using Application.NewProductDetails.Queries.Response;
using Application.ProductDetails;
using Application.ProductDetails.NewProductDetails.Queries.Response;
using MediatR;

namespace Application.NewProductDetails.Queries.Request
{
    public class GetNewProductsQueryRequest : IRequest<List<GetListNewProductsQueryResponse>>
    {
        public int Page { get; set; } = 1;
        public ShowMoreDto ShowMore { get; set; }
    }
}