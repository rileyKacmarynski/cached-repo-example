using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PlaylistTrackEntityTypeConfiguration : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("PlayListTrackId");

            builder.HasKey(e => new { e.Id, e.TrackId })
                .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.TrackId)
                .HasName("IFK_PlaylistTrackTrackId");

            builder.HasOne(d => d.Playlist)
                .WithMany(p => p.PlaylistTrack)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaylistTrackPlaylistId");

            builder.HasOne(d => d.Track)
                .WithMany(p => p.PlaylistTrack)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaylistTrackTrackId");
        }
    }
}
