namespace Application.BlogDetails.Queries.Response
{
    public class GetBlogListResponse
    {
        public int TotalBlogCount { get; set; }
        public List<GetAllBlogForUserQueryResponse> Blogs { get; set; }
    }
}