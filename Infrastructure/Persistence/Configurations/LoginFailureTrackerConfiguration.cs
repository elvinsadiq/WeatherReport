using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class LoginFailureTrackerConfiguration : IEntityTypeConfiguration<LoginFailureTracker>
    {
        public void Configure(EntityTypeBuilder<LoginFailureTracker> builder)
        {
            builder.Property(x => x.LoginTryCount)
                .IsRequired();
        }
    }
}
