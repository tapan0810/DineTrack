using DineTrack.Data;
using DineTrack.Entities.Models;
using DineTrack.Entities.Requests;
using DineTrack.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DineTrack.Service.Implementations
{
    public class ReviewService(ApplicationDbContext _context) : IReviewService
    {
        public async Task AddReviewAsync(int StudentId, CreateReviewRequest request)
        {
            if(await _context.Reviews.AnyAsync(x => x.StudentId == StudentId && x.MenuItemId == request.MenuItemId))
            {
                throw new Exception("You already reviewed this item");
            }

            var review = new Review
            {
                StudentId = StudentId,
                MenuItemId = request.MenuItemId,
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow,

            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }
    }
}
