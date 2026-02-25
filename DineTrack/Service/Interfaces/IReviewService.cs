using DineTrack.Entities.Requests;

namespace DineTrack.Service.Interfaces
{
    public interface IReviewService
    {
        Task AddReviewAsync(int StudentId, CreateReviewRequest request);
    }
}
