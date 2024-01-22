namespace Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = null!;
        public AppUserRole AppUserRole { get; set; } = null!;
        public List<LoginFailureTracker> LoginFailureTrackers { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<CartItem> CartItems { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        //public DateTime RefreshTokenCreated { get; set; }
        //public DateTime RefreshTokenExpires { get; set; }
        public string? OTPToken { get; set; }
        public DateTime OTPTokenCreated { get; set; }
        public DateTime OTPTokenExpires { get; set; }
    }
}