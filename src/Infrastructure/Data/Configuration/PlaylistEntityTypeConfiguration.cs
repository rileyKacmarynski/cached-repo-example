using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PlaylistEntityTypeConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.Property(e => e.PlaylistId).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
