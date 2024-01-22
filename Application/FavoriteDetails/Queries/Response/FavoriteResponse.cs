using Application.CartDetails.AddToCartDetails.ProductModelDetail;
using Application.ProductDetails.ProductModelDetail;

namespace Application.FavoriteDetails.Queries.Response
{
    public class FavoriteResponse
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public decimal SalePrice { get; set; }
        public ColorResponse ProductImages { get; set; }
    }
}