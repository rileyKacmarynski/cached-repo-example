using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Genre : BaseEntity
    {
        public Genre()
        {
            Track = new HashSet<Track>();
        }

        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
