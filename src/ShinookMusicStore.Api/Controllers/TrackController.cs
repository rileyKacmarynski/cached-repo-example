using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Common;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        /// <summary>
        /// Gets all tracks
        /// </summary>
        /// <returns>A list of tracks</returns>
        [HttpGet]
        [Route("api/tracks")]
        public async Task<IActionResult> Index(int? take, CancellationToken cancellationToken)
        {
            var tracks = await _trackService.GetTopTracksAsync(take);
            return Json(Result.Ok(tracks));
        }

        [HttpGet]
        [Route("api/track/{id}")]
        public async Task<IActionResult> Track(int id, CancellationToken cancellationToken)
        {
            var track = await _trackService.GetByIdAsync(id);
            return Json(Result.Ok(track));
        }
    }
}