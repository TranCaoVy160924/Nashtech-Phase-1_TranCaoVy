﻿using CommercialWebSite.Data.DataModel;
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

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostReviewAsync([FromBody] ProductReviewModel reviewModel)
        {
            bool isSucceeded = await _reviewRepository.PostReviewAsync(reviewModel);
            if (isSucceeded)
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
