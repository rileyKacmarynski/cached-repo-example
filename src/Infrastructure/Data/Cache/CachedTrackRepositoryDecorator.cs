using ApplicationCore.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CachedTrackRepositoryDecorator : IReadonlyRepository<Track>
    {
        private CacheSettings CacheSettings;
        private readonly TrackRepository _trackRepo;
        private readonly IMemoryCache _cache;
        private MemoryCacheEntryOptions cacheOptions;

        public CachedTrackRepositoryDecorator(IConfiguration configuration, TrackRepository trackRepo, IMemoryCache cache)
        {
            var settings = new CacheSettings();
            configuration.GetSection("CacheSettings").Bind(settings);
            CacheSettings = settings;
            
            _trackRepo = trackRepo;
            _cache = cache;

            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(CacheSettings.Duration));
        }

        public async Task<Track> GetByIdAsync(int id)
        {
            string key = $"{CacheSettings.Keys.Tracks}_{id}";
            Track track;
            if (_cache.TryGetValue(key, out track))
            {
                track.FromCache = true;
                return track;
            }

            track = await _trackRepo.GetByIdAsync(id);
            _cache.Set(key, track, cacheOptions);
            track.FromCache = false;
            return track;
        }

        public async Task<IEnumerable<Track>> ListAllAsync()
        {
            IEnumerable<Track> tracks;
            if(_cache.TryGetValue(CacheSettings.Keys.Tracks, out tracks))
            {
                
                foreach (var track in tracks)
                {
                    track.FromCache = true;
                }
                return tracks;
            }


            tracks = await _trackRepo.ListAllAsync();
            _cache.Set(CacheSettings.Keys.Tracks, tracks, cacheOptions);
            foreach (var track in tracks)
            {
                track.FromCache = false;
            }
            return tracks;
        }
    }
}
