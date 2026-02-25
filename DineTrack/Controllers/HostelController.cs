using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelController(IHostelService hostelService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHostels()
        {
            var hostels = await hostelService.GetAllHostelsAsync();
            return Ok(hostels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHostel(string name, string location)
        {
            await hostelService.CreateHostel(name, location);
            return Ok(new { Message = "Hostel created successfully" });
        }
    }
}
