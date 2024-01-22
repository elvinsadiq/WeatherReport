using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.Property(cm => cm.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(cm => cm.Subject)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(cm => cm.Message)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}