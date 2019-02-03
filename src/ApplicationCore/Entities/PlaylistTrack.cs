using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class PlaylistTrack : BaseEntity
    {
        public int TrackId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
