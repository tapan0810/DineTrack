using DineTrack.Entities.Requests;
using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController(IMenuService menuService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value ?? "0");
            await menuService.CreateMenuAsync(request, userId);
            return Ok(new { Message = "Menu created successfully" });
        }

        [HttpGet("today/{messId}")]
        public async Task<IActionResult> GetTodayMenu(int messId)
        {
            var menu = await menuService.GetMenuItemByIdAsync(messId);
            if (menu is null)
                return NotFound(new { Message = "No menu found for today" });
            return Ok(menu);
        }
    }
}
