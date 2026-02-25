using DineTrack.Data;
using DineTrack.Entities.Dtos;
using DineTrack.Entities.Models;
using DineTrack.Entities.Requests;
using DineTrack.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DineTrack.Service.Implementations
{
    public class MenuService(ApplicationDbContext _context) : IMenuService
    {
        public async Task CreateMenuAsync(CreateMenuRequest request, int userId)
        {
            var menu = new Menu
            {

                MenuDate = request.MenuDate,
                MealType = request.MealType,
                MessId = request.MessId,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

        }

        public async Task<MenuDto> GetMenuItemByIdAsync(int messId)
        {
            var today = DateTime.UtcNow.Date;

            var menu = await _context.Menus
                .Include(m => m.MenuItems)
                .FirstOrDefaultAsync(m => m.MessId == messId && m.MenuDate.Date == today);

            if (menu is null)
                return null;

            return new MenuDto
            {
                MenuId = menu.MenuId,
                MenuDate = menu.MenuDate,
                MealType = menu.MealType,
                Items = menu.MenuItems.Select(s => new MenuItemDto
                {
                    MenuItemId = s.MenuItemId,
                    FoodName = s.FoodName,
                    Price = s.Price,
                    IsAvailable = s.IsAvailable
                }).ToList()
            };
        }
    }
}
