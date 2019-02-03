using ApplicationCore.Entities;
using ApplicationCore.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Repositories.TrackRepositoryTests
{
    public class TopTracks
    {
        private readonly ChinookContext _context;
        private readonly EfRepository<Track> _trackRepository;

        public TopTracks()
        {
            var dbOptions = new DbContextOptionsBuilder<ChinookContext>()
                .UseInMemoryDatabase(databaseName: "GetTopTracks")
                .Options;

            _context = new ChinookContext(dbOptions);
            _trackRepository = new EfRepository<Track>(_context);
        }

        [Test]
        public async Task GetTopTracks()
        {
            var testTracks = new List<Track>
            {
                new Track{Id = 1, Score = 1 },
                new Track{Id = 2, Score = 2 },
                new Track{Id = 3, Score = 3 }
            };
            _context.AddRange(testTracks);
            _context.SaveChanges();

            var spec = new TopTracksSpecification(2);
            var tracks = await _trackRepository.ListAsync(spec);

            Assert.AreEqual(3, tracks.First().Id);
            Assert.AreEqual(2, tracks.Count());
        }
    }
}
