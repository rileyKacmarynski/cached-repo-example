using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class TrackDetailSpecification : BaseSpecification<Track>
    {
        public TrackDetailSpecification(int id)
            : base(t => t.Id == id)
        {
            Id = id;
            AddInclude(t => t.Album);
            AddInclude(t => t.Album.Artist);
            AddInclude(t => t.Genre);
        }
    }
}
