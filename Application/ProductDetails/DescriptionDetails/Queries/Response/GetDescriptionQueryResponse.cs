namespace Application.DescriptionDetails.Queries.Response
{
    public class GetDescriptionQueryResponse
    {
        public int Id { get; set; }
        public string Introduction { get; set; }
        public List<string>? ImageFiles { get; set; }

    }
}