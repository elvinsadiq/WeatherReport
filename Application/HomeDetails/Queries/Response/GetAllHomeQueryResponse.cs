using Application.ApplicationUserDetails.Queries.Response;
using Application.CategoryDetails.Queries.Response;

namespace Application.HomeDetails.Queries.Response
{
    public class GetAllHomeQueryResponse
    {
        public int Id { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}