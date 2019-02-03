using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class TrackDto
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public int AlbumId { get; set; }
        public string Artist { get; set; }
        public int ArtistId { get; set; }
        public int Score { get; set; }
        public bool FromCache { get; internal set; }
    }
}
