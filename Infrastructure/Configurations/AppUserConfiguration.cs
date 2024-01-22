using Domain.Entities;
using Domain.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : BaseEntityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(t => t.UserName).IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.FirstName).IsRequired(false)
                .HasMaxLength(100);

            builder.Property(t => t.LastName).IsRequired(false)
                .HasMaxLength(100);

            builder.Property(t => t.Email).IsRequired()
                .HasMaxLength(256);

            builder.Property(t => t.Password).IsRequired()
                .HasMaxLength(100);

            builder.HasOne(u => u.AppUserRole)
             .WithMany(r => r.AppUser)
             .HasForeignKey(u => u.RoleId)
             .IsRequired();

            builder.Property(t => t.IsActive).IsRequired();

            builder.Property(t => t.RefreshToken).IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
