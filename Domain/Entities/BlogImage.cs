namespace Domain.Entities
{
    public class BlogImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
    }
}