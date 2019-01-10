using ApplicationCore.Common;
using ApplicationCore.Tracks.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Tracks.GetTracks
{
    public class GetTracksRequest : IRequest<Result<IEnumerable<TrackDto>>> { }
}
