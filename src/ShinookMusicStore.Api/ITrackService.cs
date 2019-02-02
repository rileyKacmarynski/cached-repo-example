using Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDto>> GetTopTracksAsync(int? count);
    }
}
