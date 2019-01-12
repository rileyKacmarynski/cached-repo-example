using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Common;
using ApplicationCore.Tracks.Dtos;
using ApplicationCore.Tracks.GetTrack;
using ApplicationCore.Tracks.GetTracks;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class TrackController : Controller
    {
        private readonly IMediator _mediator;

        public TrackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all tracks
        /// </summary>
        /// <returns>A list of tracks</returns>
        [HttpGet]
        [Route("api/tracks")]
        public async Task<ActionResult<Result<IEnumerable<TrackDto>>>> Index(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTracksRequest(), cancellationToken);
        }

        [HttpGet]
        [Route("api/track/{id}")]
        public async Task<ActionResult<Result<TrackDto>>> Track(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTrackRequest(id), cancellationToken);
        }
    }
}