namespace Domain.Entities
{
    public class AppUserRole : BaseEntity
    {
        public string RoleName { get; set; } = null!;
        public List<AppUser> AppUsers { get; set; } = null!;
    }
}
