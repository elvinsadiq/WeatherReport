using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Introduction { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Sku { get; set; }
        public bool IsNew { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Description Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(4);
        public List<ProductImage>? ProductImages { get; set; }
        public List<ProductColorStock>? ProductColorStocks { get; set; }
        public List<ProductTag>? ProductTags { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Review>? Reviews { get; set; }
       

        public decimal CalculateSalePrice()
        {
            decimal discountedAmount = SalePrice * (DiscountPercent / 100);
            return SalePrice - discountedAmount;
        }
    }
}
