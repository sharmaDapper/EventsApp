using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EventsAPI.DataProvider.Interface;
using System.Threading.Tasks;
using EventsAPI.Models;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private IReviewDataProvider reviewDataProvider;

        public ReviewController(IReviewDataProvider reviewDataProvider)
        {
            this.reviewDataProvider = reviewDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewModel>> Get()
        {
            return await reviewDataProvider.GetReviews();
        }

        [HttpGet("{id}")]
        public async Task<ReviewModel> Get(int id)
        {
            return await reviewDataProvider.GetReview(id);
        }

        [HttpPost]
        public async Task Post([FromBody]ReviewModel review)
        {
            await reviewDataProvider.AddReview(review);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]ReviewModel review)
        {
            await reviewDataProvider.UpdateReview(review);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await reviewDataProvider.DeleteReview(id);
        }
    }
}
