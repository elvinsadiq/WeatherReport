namespace Application.BlogDetails.Queries.Response
{
    public class GetAllRecentPostsQueryResponse
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<string> ImageUrls { get; set; }
    }
}