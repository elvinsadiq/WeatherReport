using Application.ProductDetails.ProductModelDetail;

namespace Application.BlogDetails.Queries.Response
{
    public class GetAllBlogQueryResponse
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public CategoryResponse Category { get; set; }
        public GetUserResponse User { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string>? ImageUrls { get; set; }
    }

    public class GetUserResponse
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public AdminInfoResponse Role { get; set; }
        public bool IsActive { get; set; }
    }
}