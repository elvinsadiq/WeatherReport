using Application.ProductDetails.ProductModelDetail;

namespace Application.BlogDetails.Queries.Response
{
    public class GetByIdBlogQueryResponse
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public CategoryResponse Category { get; set; }
        public GetUserResponse User { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}