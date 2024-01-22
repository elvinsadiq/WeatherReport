namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }
        public string Ccode { get; set; }
        public List<Province> Provinces { get; set; }
    }
}
