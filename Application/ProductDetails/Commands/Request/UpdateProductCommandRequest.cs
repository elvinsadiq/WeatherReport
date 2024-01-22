using Application.DescriptionDetails.Commands.Request;
using Application.ProductDetails.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.ProductDetails.Commands.Request
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Introduction { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
        public int StockCount { get; set; }
        public string Sku { get; set; }
        public bool IsNew { get; set; }
        public UpdateDescriptionCommandRequest Description { get; set; }
        public int CategoryId { get; set; }
        public List<int>? SizeIds { get; set; }
        public List<int>? TagIds { get; set; }
        public List<UpdateProductColorImageRequest> ColorImages { get; set; }
    }
}
