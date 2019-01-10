using ApplicationCore.Common;
using ApplicationCore.Interfaces;
using ApplicationCore.Tracks.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Tracks.GetTracks
{
    public class GetTracksRequestHandler : IRequestHandler<GetTracksRequest, Result<IEnumerable<TrackDto>>>
    {
        private readonly IRepository<Track> _trackRepo;

        public GetTracksRequestHandler(IRepository<Track> trackRepo)
        {
            _trackRepo = trackRepo;
        }
        public async Task<Result<IEnumerable<TrackDto>>> Handle(GetTracksRequest request, CancellationToken cancellationToken)
        {
            var tracks = await _trackRepo.ListAllAsync();
            var dtos = tracks.Select(t => new TrackDto
            {
                TrackId = t.Id,
                TrackName = t.Name
            });
            return Result.Ok(dtos);
        }
    }
}
