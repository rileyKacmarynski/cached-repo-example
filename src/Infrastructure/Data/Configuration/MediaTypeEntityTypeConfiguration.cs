using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MediaTypeEntityTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.Property(e => e.MediaTypeId).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
