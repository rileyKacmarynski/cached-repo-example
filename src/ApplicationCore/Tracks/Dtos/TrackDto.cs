using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Tracks.Dtos
{
    public class TrackDto
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public bool FromCache { get; set; }
    }
}
