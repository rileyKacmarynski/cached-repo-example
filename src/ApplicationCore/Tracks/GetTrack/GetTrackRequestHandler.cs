using ApplicationCore.Common;
using ApplicationCore.Interfaces;
using ApplicationCore.Tracks.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Tracks.GetTrack
{
    public class GetTrackRequestHandler : IRequestHandler<GetTrackRequest, Result<TrackDto>>
    {
        private readonly IRepository<Track> _authorRepo;

        public GetTrackRequestHandler(IRepository<Track> authorRepo)
        {
            _authorRepo = authorRepo;
        }
        public async Task<Result<TrackDto>> Handle(GetTrackRequest request, CancellationToken cancellationToken)
        {
            var track = await _authorRepo.GetByIdAsync(request.Id);
            var trackDto = new TrackDto
            {
                Album = track.Album.Title,
                TrackId = track.Id,
                TrackName = track.Name,
                Artist = track.Album.Artist.Name
            };
            return Result.Ok(trackDto);
        }
    }
}
