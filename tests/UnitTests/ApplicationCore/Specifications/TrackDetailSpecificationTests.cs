using ApplicationCore.Entities;
using ApplicationCore.Specifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ApplicationCore.Specifications
{
    public class TrackDetailSpecificationTests
    {
        [Test]
        public async Task GetById()
        {
            var trackId = 1;
            var trackList = new List<Track>
            {
                new Track{Id = trackId},
                new Track{Id = 2},
            };

            var spec = new TrackDetailSpecification(trackId);
            var result = trackList
                .AsQueryable()
                .SingleOrDefault(spec.Criteria);

            Assert.AreEqual(trackId, result.Id);
        }
    }
}
