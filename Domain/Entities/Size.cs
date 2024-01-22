namespace Domain.Entities
{
    public class Size : BaseEntity
    {
        public string SizeName { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }

        public void SetDetail(string name)
        {
            this.SizeName = name;
        }
    }
}