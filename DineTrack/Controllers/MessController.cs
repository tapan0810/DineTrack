using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessController(IMessService messService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMess(string name, int hostelId, int managerId)
        {
            await messService.CreateMessAsync(name, hostelId, managerId);
            return Ok(new { Message = "Mess created successfully" });
        }
    }
}
