using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.Property(au => au.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(au => au.Latitude)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(au => au.Longitude)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}