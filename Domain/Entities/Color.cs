namespace Domain.Entities
{
    public class Color : BaseEntity
    {
        public string ColorHexCode { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public List<ProductColorStock>? ProductColorStocks { get; set; }
        public List<CartItem> CartItems { get; set; }
        public void SetDetail(string name)
        {
            this.ColorHexCode = name;
        }
    }
}