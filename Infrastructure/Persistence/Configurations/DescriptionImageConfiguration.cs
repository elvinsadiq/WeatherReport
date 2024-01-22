using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class DescriptionImageConfiguration : IEntityTypeConfiguration<DescriptionImage>
    {
        public void Configure(EntityTypeBuilder<DescriptionImage> builder)
        {
            builder.HasKey(di => di.Id);

            builder.Property(di => di.Image)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(di => di.Description)
                .WithMany(d => d.DescriptionImages)
                .HasForeignKey(di => di.DescriptionId);
        }
    }
}
