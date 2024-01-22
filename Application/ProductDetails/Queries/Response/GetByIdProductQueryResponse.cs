using Application.DescriptionDetails.Queries.Response;
using Application.ProductDetails.ProductModelDetail;

namespace Application.ProductDetails.Queries.Response
{
    public class GetByIdProductQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Introduction { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Sku { get; set; }
        public bool IsNew { get; set; }
        public int CategoryId { get; set; }
        public GetDescriptionQueryResponse Description { get; set; }
        public List<TagResponse>? Tags { get; set; }
        public List<ColorResponse>? Colors { get; set; }
        public List<SizeResponse>? Sizes { get; set; }
       

    }
}
