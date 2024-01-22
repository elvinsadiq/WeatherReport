using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BlogImageConfiguration : IEntityTypeConfiguration<BlogImage>
    {
        public void Configure(EntityTypeBuilder<BlogImage> builder)
        {
            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(pi => pi.Blog)
                .WithMany(p => p.BlogImages)
                .HasForeignKey(pi => pi.BlogId);
        }
    }
}