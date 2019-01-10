using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Playlist : BaseModel
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
