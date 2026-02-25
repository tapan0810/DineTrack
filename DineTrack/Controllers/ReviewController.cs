using DineTrack.Entities.Requests;
using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IReviewService reviewService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddReview(int StudentId, [FromBody] CreateReviewRequest request)
        {
            await reviewService.AddReviewAsync(StudentId, request);
            return Ok(new { Message = "Review added successfully" });
        }
    }
}
