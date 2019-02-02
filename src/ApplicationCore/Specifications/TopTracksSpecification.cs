using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class TopTracksSpecification : BaseSpecification<Track>
    {
        public TopTracksSpecification(int? count)
            : base(t => true)                       // this is pretty hacky, but whatever...
        {
            AddInclude(t => t.Album);
            AddInclude(t => t.Album.Artist);
            ApplyOrderByDescending(t => t.Score);
            ApplyTake(count);
        }
    }
}
