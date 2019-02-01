using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Common;
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
        public IActionResult Index(CancellationToken cancellationToken)
        {
            return Json("");
        }

        [HttpGet]
        [Route("api/track/{id}")]
        public IActionResult Track(int id, CancellationToken cancellationToken)
        {
            return Json("");
        }
    }
}