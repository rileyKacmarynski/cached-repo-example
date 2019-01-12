using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TrackRepository : EfRepository<Track>
    {
        public TrackRepository(ChinookContext context) : base(context)
        {

        }

        public override async Task<Track> GetByIdAsync(int id)
        {
            return await _context.Tracks
                .Include(t => t.Album)
                .ThenInclude(t => t.Artist)
                .FirstAsync(t => t.Id == id);
        }

        public override async Task<IEnumerable<Track>> ListAllAsync()
        {
            return await _context.Tracks
                .Include(t => t.Album)
                .ThenInclude(t => t.Artist)
                .ToListAsync();
        }
    }
}
