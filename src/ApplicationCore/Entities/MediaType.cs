using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class MediaType : BaseEntity
    {
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
