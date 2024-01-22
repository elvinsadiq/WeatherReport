namespace Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public AppUser User { get; set; }
        public int AppUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public List<BlogImage> BlogImages { get; set; }
    }
}