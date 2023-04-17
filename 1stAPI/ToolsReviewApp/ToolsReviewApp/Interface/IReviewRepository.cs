using ToolsReviewApp.Models;

namespace ToolsReviewApp.Interface
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReview(int id);

        ICollection<Review> GetReviewOfATool(int toolId);

        bool ReviewExists(int reviewId);
    }
}
