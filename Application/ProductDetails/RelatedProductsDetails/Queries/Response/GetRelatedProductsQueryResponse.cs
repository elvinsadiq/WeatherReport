using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RelatedProductsDetails.Queries.Response
{
    public class GetRelatedProductsQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
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
