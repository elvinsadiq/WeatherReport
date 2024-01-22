using Application.ProductDetails.ProductModelDetail;

namespace Application.RelatedCategoryProductDetails.Queries.Response
{
    public class GetRelatedCategoryProductQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsNew { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice => CalculateDiscountedPrice();
        public decimal DiscountPercent { get; set; }
        public List<string> ImageFiles { get; set; }

        public decimal CalculateDiscountedPrice()
        {
            return SalePrice - (SalePrice * (DiscountPercent / 100));
        }
    }
}