using DineTrack.Entities.Dtos;
using DineTrack.Entities.Requests;

namespace DineTrack.Service.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> CreateUserAsync(CreateUserRequest request);
        public Task<List<UserDto>> GetAllUsersAsync();
        public Task BlockUserAsync(int userId);
    }
}
