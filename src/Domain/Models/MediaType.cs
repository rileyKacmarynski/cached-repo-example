﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MediaType : BaseModel
    {
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
