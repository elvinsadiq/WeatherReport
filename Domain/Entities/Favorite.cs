namespace Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
    }
}