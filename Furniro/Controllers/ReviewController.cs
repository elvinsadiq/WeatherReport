using Application.ReviewDetails.Commands.Request;
using Application.ReviewDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> Add([FromBody] CreateReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            //"Review creation failed."return BadRequest(new { Message = "Review creation failed." });

            throw new Exception("Review creation failed.");
        }

        [HttpGet("ProductReviews")]
        public async Task<IActionResult> GetReviewsByProductId([FromQuery] GetAllReviewQueryRequest request)
        {
            var reviews = await _mediator.Send(request);

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdReviewQueryRequest { Id = id };
            var review = await _mediator.Send(requestModel);

            return review != null
                ? (IActionResult)Ok(review)
                : NotFound(new { Message = "Review not found." });
        }

        [HttpGet("ProductRating")]
        public async Task<IActionResult> GetProductRating([FromQuery] GetProductRatingQueryRequest request)
        {
            var response = await _mediator.Send(request);
            
            return response != null
                ? (IActionResult)Ok(response.Rate)
                : throw new Exception("Rating not found for this product");
        }

        [HttpPut]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Review updated successfully." });
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> Delete([FromBody] DeleteReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return response.IsSuccess
                ? (IActionResult)Ok(new { Message = "Review deleted successfully." })
                : NotFound(new { Message = "Review not found." });
        }
    }
}