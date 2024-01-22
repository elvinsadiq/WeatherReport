namespace Application.ReviewDetails.Queries.Response
{
    public class GetByIdReviewQueryResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AppUserId { get; set; }
        public float Rate { get; set; }
        public string Text { get; set; }
    }
}