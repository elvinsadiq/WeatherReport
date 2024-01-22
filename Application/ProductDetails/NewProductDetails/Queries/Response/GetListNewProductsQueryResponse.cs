using Application.GetProductDetails.Queries.Response;
using Application.NewProductDetails.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.NewProductDetails.Queries.Response
{
    public class GetListNewProductsQueryResponse
    {
        public int TotalProductCount { get; set; }
        public List<GetNewProductsQueryResponse> NewProducts { get; set; }
    }
}
