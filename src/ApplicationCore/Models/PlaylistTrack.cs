using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public partial class PlaylistTrack : BaseModel
    {
        public int TrackId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
