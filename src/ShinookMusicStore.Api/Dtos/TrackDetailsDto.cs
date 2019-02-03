using Api.Dtos;

namespace Api.Dtos
{
    public class TrackDetailsDto
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public int AlbumId { get; set; }
        public string Artist { get; set; }
        public int ArtistId { get; set; }
        public int Score { get; set; }
        public string Genre { get; set; }
        public string Composer { get; set; }
        public bool FromCache { get; internal set; }
    }
}