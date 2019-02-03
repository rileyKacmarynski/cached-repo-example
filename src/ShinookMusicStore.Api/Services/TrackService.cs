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
        private readonly IReadonlyRepository<Track> _trackRepository;

        public TrackService(IReadonlyRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task<TrackDetailsDto> GetByIdAsync(int id)
        {
            var spec = new TrackDetailSpecification(id);
            var track = await _trackRepository.GetSingleBySpecAsync(spec);
            return new TrackDetailsDto
            {
                TrackId = track.Id,
                Name = track.Name,
                Album = track.Album.Title,
                AlbumId = track.Album.Id,
                ArtistId = track.Album.Artist.Id,
                Artist = track.Album.Artist.Name,
                Genre = track.Genre.Name,
                FromCache = track.FromCache
            };
        }

        public async Task<IEnumerable<TrackDto>> GetTopTracksAsync(int? count)
        {
            if (count == null) count = 50;
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
                Score = t.Score,
                FromCache = t.FromCache
            });
        }
    }
}
