using Domain.Entities;

namespace Application.HomeDetails.Queries.Response
{
    public class GetByIdHomeQueryResponse
    {
        public int Id { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}