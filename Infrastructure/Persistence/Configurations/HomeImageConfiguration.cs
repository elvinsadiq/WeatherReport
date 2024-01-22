using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class HomeImageConfiguration : IEntityTypeConfiguration<HomeImage>
    {
        public void Configure(EntityTypeBuilder<HomeImage> builder)
        {
            builder.Property(pi => pi.ImageUrl)
            .IsRequired()
            .HasMaxLength(255);

            builder.HasOne(pi => pi.Home)
                .WithMany(p => p.HomeImages)
                .HasForeignKey(pi => pi.HomeId);
        }
    }
}