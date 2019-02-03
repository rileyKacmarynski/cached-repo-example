using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Artist : BaseEntity
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
