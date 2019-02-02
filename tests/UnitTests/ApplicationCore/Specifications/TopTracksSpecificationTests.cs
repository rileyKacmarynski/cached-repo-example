using ApplicationCore.Entities;
using ApplicationCore.Specifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.ApplicationCore.Specifications
{
    [TestFixture]
    public class TopTracksSpecificationTests
    {
        [Test]
        public void SortsByScoreDescending()
        {
            var spec = new TopTracksSpecification(10);

            var testTrackList = new List<Track>
            {
                new Track{Id = 1, Score = 1 },
                new Track{Id = 2, Score = 2 },
                new Track{Id = 3, Score = 3 }
            };

            var result = testTrackList
                .AsQueryable()
                .OrderByDescending(spec.OrderByDescending);

            Assert.AreEqual(3, result.First().Id);
            Assert.AreEqual(1, result.Last().Id);
        }
    }
}
