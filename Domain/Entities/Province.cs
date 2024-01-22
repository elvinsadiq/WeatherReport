namespace Domain.Entities
{
    public class Province : BaseEntity
    {
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public string ProvinceName {  get; set; }
    }
}
 