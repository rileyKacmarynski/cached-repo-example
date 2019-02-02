using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;

namespace Api
{
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> _trackRepository;

        public TrackService(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task<IEnumerable<TrackDto>> GetTopTracksAsync(int? count)
        {
            var spec = new TopTracksSpecification(count);
            var tracks = await _trackRepository.ListAsync(spec);

            return tracks.Select(t => new TrackDto
            {
                TrackId = t.Id,
                Name = t.Name,
                Artist = t.Album.Artist.Name,
                ArtistId = t.Album.ArtistId,
                Album = t.Album.Title,
                AlbumId = t.Album.Id,
                Score = t.Score
            });
        }
    }
}
