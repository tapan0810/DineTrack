using DineTrack.Data;
using DineTrack.Entities.Models;
using DineTrack.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DineTrack.Service.Implementations
{
    public class HostelService(ApplicationDbContext _context) : IHostelService
    {
        public async Task CreateHostel(string name, string location)
        {
            var hostel = new Hostel
            {

                HostelName = name,
                Location = location,
                CreateAt = DateTime.UtcNow
            };

            _context.Hostels.Add(hostel);
            await _context.SaveChangesAsync();
        }

        public Task<List<Hostel>> GetAllHostelsAsync()
        {
           return _context.Hostels.ToListAsync();
        }
    }
}
