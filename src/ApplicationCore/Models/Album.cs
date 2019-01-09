using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public partial class Album : BaseModel
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public string Title { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
