using Application.ProductDetails.ProductModelDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductPageDetails.Queries.Response
{
    public class GetByIdProductPageQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public bool IsNew { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice => CalculateDiscountedPrice();
        public decimal DiscountPercent { get; set; }
        public string Sku { get; set; }
        public CategoryResponse Category { get; set; }
        public List<TagResponse>? Tags { get; set; }
        public List<ColorResponse>? Colors { get; set; }
        public List<SizeResponse>? Sizes { get; set; }

        public decimal CalculateDiscountedPrice()
        {
            return SalePrice - (SalePrice * (DiscountPercent / 100));
        }
    }
}
