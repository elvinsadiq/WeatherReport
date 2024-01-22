namespace Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public List<ProductTag>? ProductTags { get; set; }

        public void SetDetail(string name)
        {
            this.TagName = name;
        }
    }
}
