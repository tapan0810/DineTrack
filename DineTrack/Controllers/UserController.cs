using DineTrack.Entities.Requests;
using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult> Register(CreateUserRequest request)
        {
            try
            {
                var user = await userService.CreateUserAsync(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut("Block/{userId}")]
        public async Task<ActionResult> BlockUser(int userId)
        {
            try
            {
                await userService.BlockUserAsync(userId);
                return Ok("User blocked successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
