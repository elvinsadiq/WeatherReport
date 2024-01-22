using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}