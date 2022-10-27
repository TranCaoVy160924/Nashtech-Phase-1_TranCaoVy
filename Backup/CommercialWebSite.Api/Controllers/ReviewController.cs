using CommercialWebSite.Data.DataModel;
using CommercialWebSite.Data.Repository;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;

namespace CommercialWebSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private ILogger<ReviewController> _logger;
        private IUserAccountRepository _userAccountRepository;

        public ReviewController(
            IReviewRepository reviewRepository, 
            ILogger<ReviewController> logger, 
            IUserAccountRepository userAccountRepository)
        {
            _reviewRepository = reviewRepository;
            _logger = logger;
            _userAccountRepository = userAccountRepository;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostReviewAsync([FromBody] ProductReviewModel reviewModel)
        {
            bool isSucceeded = await _reviewRepository.PostReviewAsync(reviewModel);
            if (!isSucceeded)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
