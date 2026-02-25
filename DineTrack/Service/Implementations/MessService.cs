using DineTrack.Data;
using DineTrack.Entities.Models;
using DineTrack.Service.Interfaces;

namespace DineTrack.Service.Implementations
{
    public class MessService(ApplicationDbContext _context) : IMessService
    {
     
        public Task CreateMessAsync(string name, int hostelId, int managerId)
        {
           var mess = new Mess
            {
                MessName = name,
                HostelId = hostelId,
                ManagedByUserId = managerId,
                CreatedAt = DateTime.UtcNow
            };
            _context.Messes.Add(mess);
            return _context.SaveChangesAsync();
        }
    }
}
