using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(c => c.ColorHexCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(c => c.ProductImages)
                .WithOne(pc => pc.Color)
                .HasForeignKey(pc => pc.ColorId);
        }
    }
}
