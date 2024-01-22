using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Mobile)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Hotline)
              .IsRequired()
              .HasMaxLength(15);

            builder.Property(c => c.WeekdayWorkingTime)
                .IsRequired();
            builder.Property(c => c.WeekendWorkingTime)
              .IsRequired();

            builder.Property(c => c.Address)
                .IsRequired().HasMaxLength(50);
        }
    }
}