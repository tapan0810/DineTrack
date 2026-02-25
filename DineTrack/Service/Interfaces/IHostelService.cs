using DineTrack.Entities.Models;

namespace DineTrack.Service.Interfaces
{
    public interface IHostelService
    {
        public Task<List<Hostel>> GetAllHostelsAsync();
        public Task CreateHostel(string name,string location);

    }
}
