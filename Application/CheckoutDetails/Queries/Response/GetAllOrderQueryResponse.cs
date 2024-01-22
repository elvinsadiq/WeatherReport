namespace Application.CheckoutDetails.Queries.Response
{
    public class GetAllOrderQueryResponse
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int CountryId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int ProvinceId { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalInfo { get; set; }
    }
}