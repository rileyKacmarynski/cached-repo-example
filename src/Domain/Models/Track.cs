﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Track : BaseModel
    {
        public Track()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }

        public bool FromCache { get; set; } = false;
    }
}
