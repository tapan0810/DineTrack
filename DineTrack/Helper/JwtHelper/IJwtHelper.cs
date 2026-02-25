using DineTrack.Entities.Models;

namespace DineTrack.Helper.JwtHelper
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(User user);
    }
}
