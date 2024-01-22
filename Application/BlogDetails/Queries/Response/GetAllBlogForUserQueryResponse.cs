using Application.ProductDetails.ProductModelDetail;

namespace Application.BlogDetails.Queries.Response
{
    public class GetAllBlogForUserQueryResponse
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public CategoryResponse Category { get; set; }
        public AdminInfoResponse AdminInfo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<string>? ImageUrls { get; set; }
    }
}