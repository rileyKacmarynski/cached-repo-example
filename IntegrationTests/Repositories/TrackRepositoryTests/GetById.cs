using ApplicationCore.Entities;
using ApplicationCore.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Repositories.TrackRepositoryTests
{
    public class GetById
    {
        private readonly ChinookContext _context;
        private readonly EfRepository<Track> _trackRepository;

        public GetById()
        {
            var dbOptions = new DbContextOptionsBuilder<ChinookContext>()
                .UseInMemoryDatabase(databaseName: "GetTrack")
                .Options;

            _context = new ChinookContext(dbOptions);
            _trackRepository = new EfRepository<Track>(_context);
        }

        [Test]
        public async Task GetTrack()
        {
            var trackId = 1;
            var tracks = new List<Track>
            {
                new Track { Id = trackId },
                new Track { Id = 2 }
            };
            _context.Tracks.AddRange(tracks);
            _context.SaveChanges();

            var spec = new TrackDetailSpecification(trackId);
            var trackFromRepo = await _trackRepository.GetSingleBySpecAsync(spec);

            Assert.AreEqual(trackId, trackFromRepo.Id);
        }
    }
}
