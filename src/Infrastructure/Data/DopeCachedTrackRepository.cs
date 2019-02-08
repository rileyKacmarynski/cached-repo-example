using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class DopeCachedTrackRepository : IReadonlyRepository<Track>
    {
        private readonly IDatabase _cache;
        private readonly IRepository<Track> _trackRepository;
        private readonly DistributedCacheEntryOptions _options;
        private readonly JsonSerializerSettings _jsonSerializerOptions;
        private static readonly string TopTracksKey = "Tracks:TopTracks";
        private static readonly string TracksKey = "Tracks";

        public DopeCachedTrackRepository(IConnectionMultiplexer connectionMultiplexer, IRepository<Track> trackRepository)
        {
            _cache = connectionMultiplexer.GetDatabase();
            _trackRepository = trackRepository;

            _options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
            _jsonSerializerOptions = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        }

        public Task<Track> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Track> GetSingleBySpecAsync(ISpecification<Track> spec)
        {
            var key = $"{TracksKey}:{spec.Id}";
            var trackString = _cache.StringGet(key);
            if (trackString.HasValue)
            {
                var cacheTrack = JsonConvert.DeserializeObject<Track>(trackString);
                cacheTrack.FromCache = true;
                return cacheTrack;
            }

            var track = await _trackRepository.GetSingleBySpecAsync(spec);
            _cache.StringSet(key, JsonConvert.SerializeObject(track, _jsonSerializerOptions));

            // if it's not a top track, set an expiration
            if(_cache.SortedSetRank(TopTracksKey, spec.Id) == null)
            {
                _cache.KeyExpire(key, TimeSpan.FromSeconds(10));
            }

            return track;
        }

        public async Task<IReadOnlyList<Track>> ListAsync(ISpecification<Track> spec)
        {
            // check to see if we have the top tracks cached
            var trackSet = _cache.SortedSetRangeByRank(TopTracksKey, 0, (long)spec.Take, Order.Descending);

            if (trackSet.Count() != 0 && trackSet.Count() >= spec.Take)
            {
                // use the trackSet values to send a request to the retrieve string entries
                var trackStrings = _cache.StringGet(trackSet.ToRedisKeyArray(TracksKey));
                if (trackStrings.Any(t => !t.HasValue))
                {
                    return await GetAndCacheTracksAsync(spec);
                }
                
                // deserialize each string entry into a Track object. 
                return trackStrings.Select(DeserializeTrack).ToList();
            }

            return await GetAndCacheTracksAsync(spec);
        }

        private async Task<IReadOnlyList<Track>> GetAndCacheTracksAsync(ISpecification<Track> spec)
        {
            var tracks = await _trackRepository.ListAsync(spec);
            CacheTracks(tracks);
            return tracks;
        }

        private void CacheTracks(IReadOnlyList<Track> tracks)
        {
            // Add the track ids and their score to a sorted set
            var setEntries = tracks.Select(t => new SortedSetEntry(t.Id, t.Score)).ToArray();
            _cache.SortedSetAdd(TopTracksKey, setEntries);

            // create a string entry for each track
            var kvps = tracks.Select(t => KeyValuePair.Create(
                (RedisKey)$"{TracksKey}:{t.Id}",
                (RedisValue)JsonConvert.SerializeObject(t, _jsonSerializerOptions)
            ));

            _cache.StringSet(kvps.ToArray());
        }

        private static Track DeserializeTrack(RedisValue value)
        {
            var track = JsonConvert.DeserializeObject<Track>(value);
            track.FromCache = true;
            return track;
        }

        public Task<IReadOnlyList<Track>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }

    public static class CachingExtensions
    {
        public static RedisKey[] ToRedisKeyArray(this RedisValue[] values, string baseKey) =>
            Array.ConvertAll(values.ToStringArray(), v => (RedisKey)$"{baseKey}:{v}");
    }
}
