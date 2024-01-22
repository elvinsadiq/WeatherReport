using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(au => au.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(au => au.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(au => au.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(au => au.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(au => au.Password)
                .IsRequired();

            builder.Property(au => au.RefreshToken)
                .HasMaxLength(256);

            builder.Property(au => au.RoleId)
                .IsRequired();

            builder.Property(au => au.IsActive)
                .IsRequired();

            builder.Property(au => au.OTPToken)
                .HasMaxLength(256);

            builder.HasOne(au => au.AppUserRole)
                .WithMany(ar => ar.AppUsers)
                .HasForeignKey(au => au.RoleId);

            builder.HasMany(c => c.LoginFailureTrackers)
                .WithOne(p => p.AppUser)
                .HasForeignKey(p => p.AppUserId);
        }
    }
}