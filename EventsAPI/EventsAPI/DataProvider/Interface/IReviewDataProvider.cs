using EventsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsAPI.DataProvider.Interface
{
    public interface IReviewDataProvider
    {
        Task AddReview(ReviewModel review);
        Task DeleteReview(int id);
        Task<ReviewModel> GetReview(int id);
        Task<IEnumerable<ReviewModel>> GetReviews();
        Task UpdateReview(ReviewModel review);
    }
}
