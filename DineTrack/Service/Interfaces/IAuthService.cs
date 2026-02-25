using DineTrack.Entities.Models;

namespace DineTrack.Service.Interfaces
{
    public interface IAuthService
    {
        public Task<string> LoginAsync(User request);
    }
}
