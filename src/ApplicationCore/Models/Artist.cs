using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public partial class Artist : BaseModel
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
