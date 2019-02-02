using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CachedTrackRepository : IReadonlyRepository<Track>
    {
        private readonly IDistributedCache _cache;
        private readonly IRepository<Track> _trackRepository;
        private readonly DistributedCacheEntryOptions _options;
        private readonly JsonSerializerSettings _jsonSerializerOptions;
        private static readonly string TopTracksKey = "Tracks:TopTracks";

        public CachedTrackRepository(IDistributedCache cache, IRepository<Track> trackRepository)
        {
            _cache = cache;
            _trackRepository = trackRepository;

            _options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
            _jsonSerializerOptions = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        }

        public Task<Track> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Track> GetSingleBySpecAsync(ISpecification<Track> spec)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Track>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Track>> ListAsync(ISpecification<Track> spec)
        {
            var trackString = _cache.GetString(TopTracksKey);
            if(!string.IsNullOrWhiteSpace(trackString))
            {
                return JsonConvert.DeserializeObject<IEnumerable<Track>>(trackString).ToList();
            }

            var tracks = await _trackRepository.ListAsync(spec);
            await _cache.SetStringAsync(TopTracksKey, JsonConvert.SerializeObject(tracks, _jsonSerializerOptions), _options);

            return tracks;
        }
    }
}
