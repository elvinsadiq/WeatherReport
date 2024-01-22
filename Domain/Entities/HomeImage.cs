namespace Domain.Entities
{
    public class HomeImage: BaseEntity
    {
        public string ImageUrl { get; set; }
        public Home Home { get; set; }
        public int HomeId { get; set; }
    }
}
