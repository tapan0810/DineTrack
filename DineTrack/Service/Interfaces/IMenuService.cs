using DineTrack.Entities.Dtos;
using DineTrack.Entities.Requests;

namespace DineTrack.Service.Interfaces
{
    public interface IMenuService
    {
        public Task CreateMenuAsync(CreateMenuRequest request, int userId);
        Task<MenuDto> GetMenuItemByIdAsync(int messId);
    }
}
