using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Playlist : BaseEntity
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
