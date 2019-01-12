using ApplicationCore.Common;
using ApplicationCore.Tracks.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Tracks.GetTrack
{
    public class GetTrackRequest : IRequest<Result<TrackDto>>
    {
        public int Id { get; }

        public GetTrackRequest(int id)
        {
            Id = id;
        }
    }
}
