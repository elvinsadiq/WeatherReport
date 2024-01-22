namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
        public List<Blog> Blogs { get; set; }
        public void SetDetail(string name)
        {
            this.CategoryName = name;
        }
    }
}
