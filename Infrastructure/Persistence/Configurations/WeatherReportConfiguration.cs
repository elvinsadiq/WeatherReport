using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class WeatherReportConfiguration : IEntityTypeConfiguration<WeatherReport>
    {
        public void Configure(EntityTypeBuilder<WeatherReport> builder)
        {
            builder.Property(au => au.WeatherId)
                .IsRequired();

            builder.Property(au => au.Main)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(au => au.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(au => au.Icon)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(au => au.Temp)
                .IsRequired();

            builder.Property(au => au.FeelsLike)
                .IsRequired();

            builder.Property(au => au.TempMin)
                .IsRequired();

            builder.Property(au => au.TempMax)
                .IsRequired();

            builder.Property(au => au.Pressure)
                .IsRequired();

            builder.Property(au => au.Humidity)
                .IsRequired();

            builder.Property(au => au.SeaLevel)
                .IsRequired();

            builder.Property(au => au.GroundLevel)
                .IsRequired();

            builder.Property(au => au.WindSpeed)
                .IsRequired();

            builder.Property(au => au.WindDegree)
                .IsRequired();

            builder.Property(au => au.WindGust)
                .IsRequired();

            builder.Property(au => au.Clouds)
                .IsRequired();

            builder.HasOne(au => au.District)
                .WithMany(ar => ar.WeatherReports)
                .HasForeignKey(au => au.DistrictId);
        }
    }
}